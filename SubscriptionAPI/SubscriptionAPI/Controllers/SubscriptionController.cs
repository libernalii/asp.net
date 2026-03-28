using Microsoft.AspNetCore.Mvc;
using SubscriptionAPI.Models;
using SubscriptionAPI.Repositories;

namespace SubscriptionAPI.Controllers
{
    [ApiController]
    [Route("api/v1/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private SubscriptionRepository _subscriptionRepository;

        public SubscriptionController(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Subscription subscription)
        {
            await _subscriptionRepository.Add(subscription);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Updade([FromBody] Subscription subscription)
        {
            var subscriptions = await _subscriptionRepository.Update(subscription);
            return Ok(subscriptions);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _subscriptionRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subscriptions = await _subscriptionRepository.GetAll();
            return Ok(subscriptions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscriptions = await _subscriptionRepository.GetById(id);
            return Ok(subscriptions);
        }
        [HttpGet("free")]
        public async Task<IActionResult> GetFree()
        {
            var subscriptions = await _subscriptionRepository.GetFree();
            return Ok(subscriptions);
        }

    }
}
