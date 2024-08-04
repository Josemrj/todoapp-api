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

        [HttpGet]
        public async Task<ActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var models = await _repository.GetFileAsync(cancellationToken);
            return Ok(
                models.Select(s => new
                {
                    s.Id,
                    s.Descricao,
                    s.DataConclusao,
                    s.IsConcluido
                }).ToList());
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> GetAsync(string id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetFileAsync(id, cancellationToken);
            return Ok(
                new
                {
                    model.Id,
                    model.Descricao,
                    model.DataConclusao,
                    model.IsConcluido
                });
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
