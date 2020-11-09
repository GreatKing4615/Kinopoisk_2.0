using System.ComponentModel.DataAnnotations;

namespace Kinopoisk.Domain.Core
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
