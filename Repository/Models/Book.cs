﻿using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Book:IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
