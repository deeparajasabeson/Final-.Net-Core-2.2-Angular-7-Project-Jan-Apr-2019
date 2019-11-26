using System.ComponentModel.DataAnnotations;

namespace DomainModels.ViewModels
{
    public class LoginModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
