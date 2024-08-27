using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace GrindChat.Library.Models
{
    public class UserTeam
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
