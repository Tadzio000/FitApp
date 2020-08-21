using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IPlanService
    {
        Plan GetById(string id);
        Plan Create(Plan plan);
        IEnumerable<Plan> GetAll();
    }

    public class PlanService : IPlanService
    {
        private DataContext _context;

        public PlanService(DataContext context)
        {
            _context = context;
        }

        public Plan Create(Plan plan)
        {
           
            _context.Plans.Add(plan);
            _context.SaveChanges();

            return plan;
        }

        public Plan GetById(string id)
        {

            var plan = _context.Plans.FirstOrDefault(x => x.Id == id);
            return plan;
        }
        public IEnumerable<Plan> GetAll()
        {

            return _context.Plans;
        }
    }
}


