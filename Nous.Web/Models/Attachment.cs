using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nous.Web.Models
{
    public class Attachment : BaseFileModel
    {
        [Required]
        public string RelativePath { get; set; }
        public string Label { get; set; }
    }
}
