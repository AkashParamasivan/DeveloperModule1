using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeveloperModule.Models
{
    public class Module
    {
        [Key]
        public int moduleid { get; set; }
        public string moduledesc { get; set; }
        public string projname { get; set; }
        public int devid { get; set; }

        [ForeignKey("devid")]
        public Developer Developer { get; set; }
    }
}