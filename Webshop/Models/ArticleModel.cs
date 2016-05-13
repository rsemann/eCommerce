using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public float Value { get; set; }

        public int Quantity { get; set; }
    }
}