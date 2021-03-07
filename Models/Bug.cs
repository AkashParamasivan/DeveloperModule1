using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeveloperModule.Models
{
    public class Bug
    {
        [Key]
        public int bugid { get; set; }
        public string bugdesc { get; set; }

        public string projname { get; set; }
        public int devid { get; set; }

        [ForeignKey("devid")]
        public Developer Developer { get; set; }

    }
}