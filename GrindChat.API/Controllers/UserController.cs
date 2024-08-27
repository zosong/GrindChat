using GrindChat.API.Data;
using GrindChat.Library.Models;
using GrindChat.Library.Services;
using Microsoft.AspNetCore.Mvc;



namespace GrindChat.Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        //{
        //    private readonly IUserRepository _userRepository;

        //    public UsersController(IUserRepository userRepository)
        //    {
        //        _userRepository = userRepository;
        //    }

        //    // GET: users
        //    [HttpGet]
        //    public ActionResult<IEnumerable<User>> GetUsers()
        //    {
        //        return Ok(_userRepository.GetAll());
        //    }

        //    // GET: users/5
        //    [HttpGet("{id}")]
        //    public ActionResult<User> GetUser(int id)
        //    {
        //        var user = _userRepository.GetById(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(user);
        //    }

        //    // POST: users
        //    [HttpPost]
        //    public ActionResult<User> PostUser(User user)
        //    {
        //        _userRepository.Add(user);
        //        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //    }

        //    // PUT: users/5
        //    [HttpPut("{id}")]
        //    public IActionResult PutUser(int id, User user)
        //    {
        //        if (id != user.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _userRepository.Update(user);
        //        return NoContent();
        //    }

        //    // DELETE: users/5
        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteUser(int id)
        //    {
        //        var user = _userRepository.GetById(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        _userRepository.Delete(id);
        //        return NoContent();
        //    }
        //}


        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userRepository.GetAll().Select(u => new
            {
                u.Id,
                u.Name,
                u.EmailAddress,
                u.Password, // Consider not returning passwords in response
                TeamIds = u.UserTeams.Select(ut => ut.TeamId).ToList() // Select only the TeamIds
            });
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = new
            {
                user.Id,
                user.Name,
                user.EmailAddress,
                user.Password, // Consider not returning passwords in response
                TeamIds = user.UserTeams.Select(ut => ut.TeamId).ToList() // Select only the TeamIds
            };

            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _userRepository.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(); 
            }

            _userRepository.Update(user);

            return NoContent(); 
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound(); 
            }

            _userRepository.Delete(id);

            return NoContent(); 
        }
    }
}