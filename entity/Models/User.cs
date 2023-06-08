using System;
using System.Collections.Generic;

namespace entity.Models
{
    public partial class User
    {
        public User()
        {
            Baskets = new HashSet<Basket>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string UserMail { get; set; } = null!;
        public string? UserPhone { get; set; }
        public string? UserAdress { get; set; }
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
