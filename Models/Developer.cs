using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloperModule.Models
{
    public class Developer
    {
        [Key]
        public int devid { get; set; }
        public int projectstatus { get; set; }
        public string projname { get; set; }
    }
}