﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public float Value { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}