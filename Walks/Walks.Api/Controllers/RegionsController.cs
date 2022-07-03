using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.Api.Data;
using Walks.Api.Models.Domains;
using Walks.Api.Models.DTOs;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RegionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRegionRepository repo;

        public RegionsController(IMapper mapper, IRegionRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegionsAsync()
        {
            var regions = await repo.GetAllAsync();
            var regionsDto = mapper.Map <IReadOnlyList<RegionDto>>(regions);
            return Ok(regionsDto);
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetRegionAsync))]
        public async Task<IActionResult>GetRegionAsync(Guid id)
        {
            var region = await repo.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody]AddRegionRequestDto regionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var region = mapper.Map<Region>(regionDto);

            var newRegion = await repo.AddAsync(region);
            var responseData = mapper.Map<RegionDto>(newRegion);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = responseData.Id }, responseData);
 
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, [FromBody] UpdateRegionRequestDto regionDto)
        {
          
            if (id != regionDto.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var region = mapper.Map<Region>(regionDto);

            var updateRegion = await repo.UpdateAsync(id,region);
            var respnseData = mapper.Map<RegionDto>(updateRegion);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await repo.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
