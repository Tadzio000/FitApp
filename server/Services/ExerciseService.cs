using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IExerciseService
    {
        Exercise GetById(string id);
        Exercise Create(Exercise Exercise);
        IEnumerable<Exercise> GetAll();
    }

    public class ExerciseService : IExerciseService
    {
        private DataContext _context;

        public ExerciseService(DataContext context)
        {
            _context = context;
        }

        public Exercise Create(Exercise exercise)
        {
           
            _context.Exercises.Add(exercise);
            _context.SaveChanges();

            return exercise;
        }

        public Exercise GetById(string id)
        {

            var exercise = _context.Exercises.FirstOrDefault(x => x.ExerciseId == id);
            return exercise;
        }
        public IEnumerable<Exercise> GetAll()
        {

            return _context.Exercises;
        }
    }
}


