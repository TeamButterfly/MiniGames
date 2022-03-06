using System;
using System.Text.Json.Serialization;

namespace API.JsonModels
{
    public class AccountModel
    {
        public Guid AccountId { get; set; }

        public int Points { get; set; }

        public virtual UserModel User { get; set; }
    }
}
