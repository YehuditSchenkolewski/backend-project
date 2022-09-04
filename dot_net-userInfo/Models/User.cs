using System;
using System.Collections.Generic;

namespace dot_net_userInfo.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public string? JoinedAt { get; set; }
        public string? Avatar { get; set; }

        public ICollection<Project> Project { get; set; } = null!;
    }
}

