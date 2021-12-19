using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNT.Shared.Enum;
using TNT.Shared.IRepositories;

namespace TNT.WebAPI.Controllers
{
    public abstract class RestController<TDto, TEntity> : ControllerBase
    {
        protected readonly IRepository<TDto, TEntity> _repository;

        internal protected RestController(IRepository<TDto, TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            if (result.Status != RepositoryActionStatus.Ok)
                return BadRequest(result.Error);

            return Ok(result.Entity);
        }

        [HttpGet()]
        [HttpHead]
        public async Task<IActionResult> GetAsync([FromQuery] TDto entity)
        {
            var result = await _repository.GetAsync(entity);
            if (result.Status != RepositoryActionStatus.Ok)
                return BadRequest(result.Error);

            return Ok(result.Entity);
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] TDto entity)
        {
            if (entity == null)
                return BadRequest();
            else if (!ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var result = await _repository.CreateAsync(entity);
            if (result.Status == RepositoryActionStatus.Created)
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}", result.Entity);

            return BadRequest(result.Error);
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TDto entity)
        {
            if (entity == null)
                return BadRequest(ModelState);
            else if (!ModelState.IsValid)
                return BadRequest(this.ModelState);

            var result = await _repository.UpdateAsync(entity);
            if (result.Status == RepositoryActionStatus.Updated)
                return Ok(result.Entity);
            else if (result.Status == RepositoryActionStatus.NotFound)
                return NotFound();
            else if (result.Status == RepositoryActionStatus.Forbidden)
                return Forbid();

            return BadRequest(result.Error);
        }

        [HttpPatch()]
        public async Task<IActionResult> PatchAsync([FromBody] TDto entity)
        {
            if (entity == null)
                return BadRequest(ModelState);
            else if (!ModelState.IsValid)
                return BadRequest(this.ModelState);

            var result = await _repository.PatchAsync(entity);
            if (result.Status == RepositoryActionStatus.Updated)
                return Ok(result.Entity);
            else if (result.Status == RepositoryActionStatus.NotFound)
                return NotFound();
            else if (result.Status == RepositoryActionStatus.Forbidden)
                return Forbid();

            return BadRequest(result.Error);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAsync(int id, int customerId)
        {
            var result = await _repository.DeleteAsync(id, customerId);
            if (result.Status == RepositoryActionStatus.Deleted)
                return Ok();
            else if (result.Status == RepositoryActionStatus.NotFound)
                return NotFound();
            else if (result.Status == RepositoryActionStatus.Forbidden)
                return Forbid();

            return BadRequest(result.Error);
        }
    }
}
