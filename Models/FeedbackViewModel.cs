using System.ComponentModel.DataAnnotations;

namespace MemoryBook.Models
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Email обязателен.")]
        public required string Email { get; set; }

        public string? Message { get; set; }

        [DataType(DataType.Upload)]
        // [Display(Name = "Файл (ZIP, RAR, 7Z, TAR до 20МБ)")]
        [Required(ErrorMessage = "Please select file")]
        public required IFormFile File { get; set; }
    }
}
