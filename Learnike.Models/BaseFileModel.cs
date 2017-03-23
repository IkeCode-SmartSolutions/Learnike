using System.ComponentModel.DataAnnotations;

namespace Learnike.Models
{
    public class BaseFileModel : BaseModel
    {
        [Required]
        public long Size { get; set; }

        public string Extension { get; set; }
    }
}