using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;


using AutoMapper;

using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlansController : ControllerBase
    {
        private IPlanService _planService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
       
        public PlansController(
            IPlanService planService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _planService = planService ;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]CreatePlan model)
        {

            var plan = _mapper.Map<Plan>(model);

            try
            {
                // create plan
                _planService.Create(plan);
                return Ok(new
                {
                    plan.Id,
                    plan.Title,
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an cexception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {

            var plan = _planService.GetById(id);

            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var plans = _planService.GetAll();
            return Ok(plans);
        }
    }
}
