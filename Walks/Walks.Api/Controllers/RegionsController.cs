using Microsoft.AspNetCore.Mvc;
using Walks.Api.Data;
using Walks.Api.Models.DTOs;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository repo;

        public RegionsController(IRegionRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetRegions()
        {
            var regions = repo.GetAll();


            // region DTO
            var regionsDto = new List<RegionDto>();

            regions.ToList().ForEach(r =>
               {
                   var regionDto = new RegionDto
                   {
                       Id = r.Id,
                       Code = r.Code,
                       Name = r.Name,
                       Lat = r.Lat,
                       Long = r.Long,
                       Population = r.Population
                   };

                   regionsDto.Add(regionDto);
               });

            return Ok(regionsDto);
        }
    }
}
