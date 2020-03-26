﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        public int IdEnrollment { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string IndexNumber { get; set; }

        override public string ToString()
        {
            return this.IdEnrollment + this.FirstName + this.LastName + this.BirthDate + this.IndexNumber;
        }
    }
}
