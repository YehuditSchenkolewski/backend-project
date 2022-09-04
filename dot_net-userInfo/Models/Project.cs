using System;
using System.Collections.Generic;

namespace dot_net_userInfo.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Score { get; set; }
        public int? DurationInDays { get; set; }
        public int? BugsCount { get; set; }
        public bool? MadeDadeline { get; set; }
        public int? UserId { get; set; }

        public virtual User IdUser { get; set; } = null!;
    }
}
