using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walks.Api.Models.Domains;
using Walks.Api.Models.DTOs;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository repo;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            var walks = await repo.GetAllAsync();
            var walkDto = mapper.Map<IReadOnlyList<WalkDto>>(walks);
            return Ok(walkDto);
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetWalkAsync))]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await repo.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequestDto walkDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walk = mapper.Map<Walk>(walkDto);

            var newWalk = await repo.AddAsync(walk);
            var responseData = mapper.Map<AddWalkRequestDto>(newWalk);

            return CreatedAtAction(nameof(GetWalkAsync), new { id = newWalk.Id }, responseData);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync(Guid id, [FromBody] UpdateWalkRequestDto walkDto)
        {

            if (id != walkDto.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walk = mapper.Map<Walk>(walkDto);

            var updateWalk = await repo.UpdateAsync(id, walk);
            var respnseData = mapper.Map<UpdateRegionRequestDto>(updateWalk);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walk = await repo.DeleteAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
