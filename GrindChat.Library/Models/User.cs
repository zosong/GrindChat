using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FreeSql.DataAnnotations;


namespace GrindChat.Library.Models
{




    public class User
    {[Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public User()
        {
            Id = 0;
            Name = string.Empty;
            EmailAddress = string.Empty;
            Password = string.Empty;
        }

    }

}
