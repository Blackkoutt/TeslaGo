﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces;

namespace TeslaGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController(ICarModelService carModelService, IFileService fileService) : ControllerBase
    {
        private readonly ICarModelService _carModelService = carModelService;
        private readonly IFileService _fileService = fileService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCarModels([FromQuery] CarModelQuery query)
        {
            Log.Information("Getting cars");
            var result = await _carModelService.GetAllAsync(query);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCarModelById([FromRoute] int id)
        {
            Log.Information("Getting car id: {@id}", id);
            var result = await _carModelService.GetOneAsync(id);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateCarModel([FromBody] CarModelRequestDto CarModelRequestDto)
        {
            var result = await _carModelService.AddAsync(CarModelRequestDto);
            return result.IsSuccessful ? Created() : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateCarModel([FromRoute] int id, [FromBody] CarModelRequestDto CarModelRequestDto)
        {
            var result = await _carModelService.UpdateAsync(id, CarModelRequestDto);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteCarModel([FromRoute] int id)
        {
            var result = await _carModelService.DeleteAsync(id);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }

        [HttpGet("{id:int}/image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCarModelImage([FromRoute] int id)
        {
            var result = await _fileService.GetCarModelImage(id);
            return result.IsSuccessful 
                ? File(result.Value.Data, result.Value.ContentType, result.Value.FileName) 
                : result.Error.Handle(this);
        }
    }
}
