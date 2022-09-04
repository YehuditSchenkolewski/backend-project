using System;
using System.Collections.Generic;

namespace dot_net_userInfo.Models
{
    public partial class Auth
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public int? UserId { get; set; }

        public virtual User IdUser { get; set; } = null!;
    }
}

