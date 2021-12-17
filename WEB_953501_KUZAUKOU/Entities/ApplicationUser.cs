using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WEB_953501_KUZAUKOU.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
