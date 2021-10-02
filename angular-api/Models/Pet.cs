﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angular_api.Models
{
    public class Pet
    {
        public Guid PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string ImageBase64 { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
