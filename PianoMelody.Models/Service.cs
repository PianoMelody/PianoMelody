﻿using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
