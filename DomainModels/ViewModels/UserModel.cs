using System.ComponentModel.DataAnnotations;

namespace DomainModels.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
