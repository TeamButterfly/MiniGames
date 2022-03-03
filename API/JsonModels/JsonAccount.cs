using System;
using System.Text.Json.Serialization;

namespace API.JsonModels
{
    public class JsonAccount
    {
        public Guid AccountId { get; set; }

        public int Points { get; set; }

        public Guid UserId { get; set; }

        public virtual JsonUser User { get; set; }
    }
}
