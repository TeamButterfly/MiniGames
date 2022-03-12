using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class UserModelUpdate : UserModel
    {
        [Required(ErrorMessage = "Password er påkrævet")]
        public string Password { get; set; }
    }
}
