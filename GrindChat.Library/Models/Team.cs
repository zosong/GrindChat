using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace GrindChat.Library.Models
{
    public class Team
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public Team()
        {
  
            TeamName = string.Empty;
            AdminId = 0;
            Admin = new User();

        }

    }
}
