using System;
using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class UserModel
    {
        [Required(ErrorMessage = "Brugernavnet er påkrævet")]
        public string Username { get; set; }
    }
}
