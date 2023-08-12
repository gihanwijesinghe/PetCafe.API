﻿using System.ComponentModel.DataAnnotations;

namespace PetCafe.API.APIModels
{
    public class CafePost
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
