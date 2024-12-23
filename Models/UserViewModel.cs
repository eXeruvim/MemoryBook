


using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MemoryBook.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Логин обязателен.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        public string Password { get; set; }
    }
}
