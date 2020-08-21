using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IPlanService
    {
        Plan Create(Plan plan, string title);
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


    }
}


