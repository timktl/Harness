using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Models.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is not valid")]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 130, ErrorMessage = "Age must be between 0 and 130")]
        public int Age { get; set; }
    }
}
