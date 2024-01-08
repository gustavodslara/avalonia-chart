using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace xamarinchart.Models
{
    public class Programmer
    {
        [Key]
        public string Name { get; set; }
        public int Demand { get; set; }
        public int Offer { get; set; }
    }
}
