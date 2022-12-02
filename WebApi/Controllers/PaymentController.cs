using System;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.UseCases.Commands;
using Application.UseCases.Models;
using Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PaymentController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPersonQuery _personQuery;
        public PaymentController(IMediator mediator, IPersonQuery personQuery)
        {
            _mediator = mediator;
            _personQuery = personQuery;
        }


        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Get(int paymentId)
        {
            return Ok(await _personQuery.Get(paymentId));
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> GetRange(int paymentId,DateTime from,DateTime to)
        {
            return Ok(await _personQuery.GetRange(paymentId, from,to));
        }


        [HttpPost("{datatype}/[controller]/[action]")]
        public async Task<IActionResult> Add([FromBody] Payload data)
        {
            await _mediator.Send(new AddPaymentCommand() {Data = data});
            
            return Ok(ServiceResult.Ok(data));
        }


        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentCommand data)
        {
            return Ok(ServiceResult.Ok(await _mediator.Send(data)));
        }


        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Delete([FromBody] DeletePaymentCommand data)
        {
            return Ok(ServiceResult.Ok(await _mediator.Send(data)));
        }
    }
}