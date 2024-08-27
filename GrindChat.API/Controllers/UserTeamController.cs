using GrindChat.Library.Models;
using GrindChat.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrindChat.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTeamsController : ControllerBase
    {
        //    private readonly IUserTeamRepository _userteamRepository;

        //    public UserTeamsController(IUserTeamRepository userteamRepository)
        //    {
        //        _userteamRepository = userteamRepository;
        //    }

        //    // GET: userteams
        //    [HttpGet]
        //    public ActionResult<IEnumerable<UserTeam>> GetUserTeams()
        //    {
        //        return Ok(_userteamRepository.GetAll());
        //    }

        //    // GET: userteams/5
        //    [HttpGet("{id}")]
        //    public ActionResult<UserTeam> GetUserTeam(int id)
        //    {
        //        var userteam = _userteamRepository.GetById(id);
        //        if (userteam == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(userteam);
        //    }

        //    // POST: userteams
        //    [HttpPost]
        //    public ActionResult<UserTeam> PostUserTeam(UserTeam userteam)
        //    {
        //        _userteamRepository.Add(userteam);
        //        return CreatedAtAction(nameof(GetUserTeam), new { id = userteam.Id }, userteam);
        //    }

        //    // PUT: userteams/5
        //    [HttpPut("{id}")]
        //    public IActionResult PutUserTeam(int id, UserTeam userteam)
        //    {
        //        if (id != userteam.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _userteamRepository.Update(userteam);
        //        return NoContent();
        //    }

        //    // DELETE: userteams/5
        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteUserTeam(int id)
        //    {
        //        var userteam = _userteamRepository.GetById(id);
        //        if (userteam == null)
        //        {
        //            return NotFound();
        //        }

        //        _userteamRepository.Delete(id);
        //        return NoContent();
        //    }
        //}

        private readonly IUserTeamRepository _userTeamRepository;

        public UserTeamsController(IUserTeamRepository userTeamRepository)
        {
            _userTeamRepository = userTeamRepository;
        }

        // GET: api/UserTeams
        [HttpGet]
        public ActionResult<IEnumerable<UserTeam>> GetUserTeams()
        {
            var userTeams = _userTeamRepository.GetAll();
            return Ok(userTeams); 
        }

        // GET: api/UserTeams/5
        [HttpGet("{id}")]
        public ActionResult<UserTeam> GetUserTeam(int id)
        {
            var userTeam = _userTeamRepository.GetById(id);

            if (userTeam == null)
            {
                return NotFound(); 
            }

            return Ok(userTeam);
        }

        // POST: api/UserTeams
        [HttpPost]
        public ActionResult<UserTeam> PostUserTeam(UserTeam userTeam)
        {
            _userTeamRepository.Add(userTeam);

            return CreatedAtAction(nameof(GetUserTeam), new { id = userTeam.Id }, userTeam); 
           
        }

        // PUT: api/UserTeams/5
        [HttpPut("{id}")]
        public IActionResult PutUserTeam(int id, UserTeam userTeam)
        {
            if (id != userTeam.Id)
            {
                return BadRequest(); 
            }

            _userTeamRepository.Update(userTeam);

            return NoContent(); 
        }

        // DELETE: api/UserTeams/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserTeam(int id)
        {
            var userTeam = _userTeamRepository.GetById(id);
            if (userTeam == null)
            {
                return NotFound(); 
            }

            _userTeamRepository.Delete(id);

            return NoContent();
        }
    }
}
