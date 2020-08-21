using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CreateExercise
    {

        public string[] Materials { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Times { get; set; }
        [Required]
        public int Series { get; set; }
    }
}
