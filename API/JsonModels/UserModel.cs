using System;
using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class UserModel
    {
        public Guid? UserId { get; set; }

        [Required(ErrorMessage = "Bruger navnet er påkrævet")]
        public string Username { get; set; }
    }
}
