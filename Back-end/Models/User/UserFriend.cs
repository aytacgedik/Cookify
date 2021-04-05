using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.Models
{
    public partial class UserFriend
    {
        public int UserFollowerId { get; set; }
        public int UserFollowedId { get; set; }

        public virtual User UserFollowed { get; set; }
        public virtual User UserFollower { get; set; }
    }
}
