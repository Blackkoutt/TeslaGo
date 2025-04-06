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
    public class PaymentMethodsController(IPaymentMethodService paymentMethodService) : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService = paymentMethodService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentMethods([FromQuery] PaymentMethodQuery query)
        {
            var result = await _paymentMethodService.GetAllAsync(query);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentMethodById([FromRoute] int id)
        {
            var result = await _paymentMethodService.GetOneAsync(id);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] PaymentMethodRequestDto PaymentMethodRequestDto)
        {
            var result = await _paymentMethodService.AddAsync(PaymentMethodRequestDto);
            return result.IsSuccessful
                ? CreatedAtAction(nameof(GetPaymentMethodById), new { id = result.Value.Id }, result.Value)
                : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdatePaymentMethod([FromRoute] int id, [FromBody] PaymentMethodRequestDto PaymentMethodRequestDto)
        {
            var result = await _paymentMethodService.UpdateAsync(id, PaymentMethodRequestDto);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeletePaymentMethod([FromRoute] int id)
        {
            var result = await _paymentMethodService.DeleteAsync(id);
            return result.IsSuccessful ? NoContent() : result.Error.Handle(this);
        }
    }
}
