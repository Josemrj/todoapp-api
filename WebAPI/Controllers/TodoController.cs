using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        public TodoController(TodoRepository repository)
        {
            _repository = repository;
        }
        private readonly TodoRepository _repository;

        [HttpGet, Route("{id}")]
        public async Task GetAsync(string id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetFileAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task CreateAsync(CancellationToken cancellationToken)
        {
            
        }

        [HttpPut]
        public async Task EditAsync(CancellationToken cancellationToken)
        {

        }

        [HttpDelete]
        public async Task DeleteAsync(CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync("", cancellationToken);
        }

    }
}
