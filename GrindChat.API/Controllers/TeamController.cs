using GrindChat.Library.Models;
using GrindChat.Library.Services;


using Microsoft.AspNetCore.Mvc;
namespace GrindChat.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        //    private readonly ITeamRepository _teamRepository;

        //    public TeamsController(ITeamRepository teamRepository)
        //    {
        //        _teamRepository = teamRepository;
        //    }

        //    // GET: teams
        //    [HttpGet]
        //    public ActionResult<IEnumerable<Team>> GetTeams()
        //    {
        //        return Ok(_teamRepository.GetAll());
        //    }

        //    // GET: teams/5
        //    [HttpGet("{id}")]
        //    public ActionResult<Team> GetTeam(int id)
        //    {
        //        var team = _teamRepository.GetById(id);
        //        if (team == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(team);
        //    }

        //    // POST: teams
        //    [HttpPost]
        //    public ActionResult<Team> PostTeam(Team team)
        //    {
        //        _teamRepository.Add(team);
        //        return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        //    }

        //    // PUT: teams/5
        //    [HttpPut("{id}")]
        //    public IActionResult PutTeam(int id, Team team)
        //    {
        //        if (id != team.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _teamRepository.Update(team);
        //        return NoContent();
        //    }

        //    // DELETE: teams/5
        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteTeam(int id)
        //    {
        //        var team = _teamRepository.GetById(id);
        //        if (team == null)
        //        {
        //            return NotFound();
        //        }

        //        _teamRepository.Delete(id);
        //        return NoContent();
        //    }
        //}

        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            var teamDtos = teams.Select(t => new TeamDto
            {
                Id = t.Id,
                TeamName = t.TeamName,
                Admin = new UserAdminDto
                {
                    Id = t.Admin.Id,
                    Name = t.Admin.Name,
                    EmailAddress = t.Admin.EmailAddress
                },
                UserTeams = t.UserTeams.Select(ut => ut.UserId) // 提取UserTeams中的UserId
            });
            return Ok(teamDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            var teamDto = new TeamDto
            {
                Id = team.Id,
                TeamName = team.TeamName,
                Admin = new UserAdminDto
                {
                    Id = team.Admin.Id,
                    Name = team.Admin.Name,
                    EmailAddress = team.Admin.EmailAddress
                },
                UserTeams = team.UserTeams.Select(ut => ut.UserId)
            };
            return Ok(teamDto);
        }

        [HttpPost]
        public ActionResult<Team> AddTeam(Team team)
        {
            var createdTeam = _teamRepository.Add(team);
            return CreatedAtAction(nameof(GetTeam), new { id = createdTeam.Id }, createdTeam);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }
            _teamRepository.Update(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            _teamRepository.Delete(id);
            return NoContent();
        }

    }
}