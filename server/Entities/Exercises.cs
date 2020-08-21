using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Exercise
    {
        public Exercise()
        {
            ExerciseId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ExerciseId { get; set; }
        public string[] Materials { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Times { get; set; }
        public int Series { get; set; }
    }
}