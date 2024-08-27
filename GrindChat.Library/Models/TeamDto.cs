using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindChat.Library.Models
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public UserAdminDto Admin { get; set; }
        public IEnumerable<int> UserTeams { get; set; }
    }

    public class UserAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}