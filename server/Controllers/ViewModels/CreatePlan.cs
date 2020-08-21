using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CreatePlan
    {
        [Required]
        public string Title { get; set; }
        //public string[] ExerciseId { get; set; }
    }
}