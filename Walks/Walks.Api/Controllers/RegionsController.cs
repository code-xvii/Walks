using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly IRegionRepository repo;

        public RegionsController(IMapper mapper, IRegionRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetRegions()
        {
            var regions = repo.GetAll();
            var model = mapper.Map <IReadOnlyList<RegionDto>>(regions);
            return Ok(model);
        }
    }
}
