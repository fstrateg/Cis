using System.ComponentModel.DataAnnotations;

namespace CisClient.Src.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите имя пользователя!")]
        public string User { get; set; }

        [Required(ErrorMessage ="Введите пароль!")]
        public string Password { get; set; }
    }
}
