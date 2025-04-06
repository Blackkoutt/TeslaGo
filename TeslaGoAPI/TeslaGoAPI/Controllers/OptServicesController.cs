using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces;

namespace TeslaGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptServicesController(IOptServiceService optServiceService) : ControllerBase
    {
        private readonly IOptServiceService _optServiceService = optServiceService;

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOptServices([FromQuery] OptServiceQuery query)
        {
            var result = await _optServiceService.GetAllAsync(query);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOptServiceById([FromRoute] int id)
        {
            var result = await _optServiceService.GetOneAsync(id);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateOptService([FromBody] OptServiceRequestDto OptServiceRequestDto)
        {
            var result = await _optServiceService.AddAsync(OptServiceRequestDto);
            return result.IsSuccessful
                ? CreatedAtAction(nameof(GetOptServiceById), new { id = result.Value.Id }, result.Value)
                : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateOptService([FromRoute] int id, [FromBody] OptServiceRequestDto OptServiceRequestDto)
        {
            var result = await _optServiceService.UpdateAsync(id, OptServiceRequestDto);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteOptService([FromRoute] int id)
        {
            var result = await _optServiceService.DeleteAsync(id);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }
    }
}
