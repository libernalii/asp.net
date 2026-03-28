using Microsoft.AspNetCore.Mvc;
using SubscriptionAPI.Models;
using SubscriptionAPI.Repositories;

namespace SubscriptionAPI.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            await _userRepository.Add(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Updade([FromBody] User user)
        {
            var users = await _userRepository.Update(user);
            return Ok(users);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userRepository.GetById(id);
            return Ok(users);
        }
        [HttpGet("a")]
        public async Task<IActionResult> GetByA()
        {
            var users = await _userRepository.GetByA();
            return Ok(users);
        }
        [HttpGet("subscription")]
        public async Task<IActionResult> GetBySubscription()
        {
            var users = await _userRepository.GetBySubscription();
            return Ok(users);
        }
        [HttpGet("premium")]
        public async Task<IActionResult> GetByPremium()
        {
            var users = await _userRepository.GetBySubscription();
            return Ok(users);
        }
        [HttpGet("top")]
        public async Task<IActionResult> GetBySubscriptions()
        {
            var users = await _userRepository.Get();
            return Ok(users);
        }
    }
}