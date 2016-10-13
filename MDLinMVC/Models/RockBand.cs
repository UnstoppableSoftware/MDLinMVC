using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MDLinMVC.Models
{
    public partial class RockBand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginationDate { get; set; }
        public List<object> Members { get; set; }
    }
}