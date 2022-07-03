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
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly IWalkDifficultyRepository repo;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalkDifficulties()
        {
            var walkDifficulties = await repo.GetAllAsync();
            var walkDifficultiesDto = mapper.Map<IReadOnlyList<WalkDifficultyDto>>(walkDifficulties);
            return Ok(walkDifficultiesDto);
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetWalkDifficulty))]
        public async Task<IActionResult> GetWalkDifficulty(Guid id)
        {
            var walkDifficulty = await repo.GetAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDto = mapper.Map<WalkDifficultyDto>(walkDifficulty);

            return Ok(walkDifficultyDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkDifficultyRequestDto walkDifficultyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walkDifficulty = mapper.Map<WalkDifficulty>(walkDifficultyDto);

            var newWalkDifficulty = await repo.AddAsync(walkDifficulty);
            var responseData = mapper.Map<AddWalkDifficultyRequestDto>(newWalkDifficulty);

            return CreatedAtAction(nameof(GetWalkDifficulty), new { id = newWalkDifficulty.Id }, responseData);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync(Guid id, [FromBody] UpdateWalkRequestDto walkDifficultyDto)
        {

            if (id != walkDifficultyDto.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walk = mapper.Map<WalkDifficulty>(walkDifficultyDto);

            var updatedWalkDifficulty = await repo.UpdateAsync(id, walk);
            var respnseData = mapper.Map<UpdateWalkRequestDto>(updatedWalkDifficulty);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walkDifficulty = await repo.DeleteAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
