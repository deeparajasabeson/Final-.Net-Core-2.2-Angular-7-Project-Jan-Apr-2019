using Microsoft.AspNetCore.Identity;
using System;

namespace DomainModels.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
