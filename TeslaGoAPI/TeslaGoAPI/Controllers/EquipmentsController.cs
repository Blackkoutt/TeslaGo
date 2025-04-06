using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Services.Services;

namespace TeslaGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController(IEquipmentService equipmentService) : ControllerBase
    {
        private readonly IEquipmentService _equipmentService = equipmentService;

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEquipments([FromQuery] EquipmentQuery query)
        {
            var result = await _equipmentService.GetAllAsync(query);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEquipmentById([FromRoute] int id)
        {
            var result = await _equipmentService.GetOneAsync(id);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentRequestDto EquipmentRequestDto)
        {
            var result = await _equipmentService.AddAsync(EquipmentRequestDto);
            return result.IsSuccessful 
                ? CreatedAtAction(nameof(GetEquipmentById), new { id = result.Value.Id }, result.Value) 
                : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateEquipment([FromRoute] int id, [FromBody] EquipmentRequestDto EquipmentRequestDto)
        {
            var result = await _equipmentService.UpdateAsync(id, EquipmentRequestDto);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteEquipment([FromRoute] int id)
        {
            var result = await _equipmentService.DeleteAsync(id);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }
    }
}
