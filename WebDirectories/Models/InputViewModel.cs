using System.ComponentModel.DataAnnotations;
using WebDirectories.Additionals;

namespace WebDirectories.Models
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".json", ".txt" })]
        public IFormFile jsonFile { get; set; }
    }
}
