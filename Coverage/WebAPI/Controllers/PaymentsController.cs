using Microsoft.AspNetCore.Mvc;
using Coverage.Services.BusinessLogic.Interfaces;
using Coverage.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coverage.Core.Models;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentDTO>> GetPaymentById(int id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null) return NotFound(new { Message = "Payment not found." });

        return Ok(payment);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetUserPayments(int userId)
    {
        var payments = await _paymentService.GetPaymentsByUserIdAsync(userId);
        return Ok(payments);
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentDTO processPaymentDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var processedPayment = await _paymentService.ProcessPaymentAsync(processPaymentDTO);
        return CreatedAtAction(nameof(GetPaymentById), new { id = processedPayment.Id }, processedPayment);
    }
}
