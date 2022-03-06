using System;
using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class UserModel
    {
        [Required(ErrorMessage = "Bruger navnet er påkrævet")]
        public string Username { get; set; }
    }
}
