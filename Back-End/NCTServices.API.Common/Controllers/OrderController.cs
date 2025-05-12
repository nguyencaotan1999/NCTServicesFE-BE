using Microsoft.AspNetCore.Mvc;
using NCTServices.API.Common.Models;
using NCTServices.Application.Common.Services.Admin.Order.Commands;
using NCTServices.Application.Common.Services.CheckOut.Queries;
using NCTServices.Application.Common.Services.Order.Queries;
using NCTServices.Application.Common.Services.OrderDetail.Commands;
using NCTServices.Application.Common.Services.OrderDetail.Queries;
using NCTServices.Model.Requests;

namespace NCTServices.API.Common.Controllers
{
    public class OrderController : BaseApiController<OrderController>
    {
        [HttpGet]
        [Route("OrderDetail")]
        public async Task<IActionResult> GetOrderdetail(int UserId)
        {
            try
            {
                var listProducts = await _mediator.Send(new GetOrderDetailById(UserId));
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }

        [HttpPost]
        [Route("UpdateOrderDetail")]
        public async Task<IActionResult> AddOrUpdateOrderDetail(List<OrderDetailRequest> OrderDetail)
        {
            try
            {
                var listProducts = await _mediator.Send(new UpdateOrderDetailCommands(OrderDetail));
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }

        [HttpDelete]
        [Route("OrderDetail")]
        public async Task<IActionResult> DeleteOrderDetail(int OrderDetailId)
        {
            try
            {
                var listProducts = await _mediator.Send(new DeleteOrderDetailCommands(OrderDetailId));
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }
        [HttpGet]
        [Route("Order")]
        public async Task<IActionResult> GetAllOrderByUserId(int id)
        {
            try
            {
                var listorders = await _mediator.Send(new GetAllOrder(id));
                return Ok(listorders.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // UnComplete. need to check logic detail
        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> CreateOrderByAdmin()
        {
            try
            {
                var listorders = await _mediator.Send(new CreateOrderByAdmin());
                return Ok(listorders.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // UnComplete. need to check logic detail
        [HttpPut]
        [Route("Order")]
        public async Task<IActionResult> UpdateOrderByAdmin([FromBody] OrderRequestByAdmin request  )
        {
            try
            {
                var UpdateOrder = new OrderRequest();

                UpdateOrder.Status = request.Status;
                var listorders = await _mediator.Send(new UpdateOrderByAdmin(UpdateOrder));
                return Ok(listorders.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // UnComplete. need to check logic detail
        [HttpDelete]
        [Route("Order")]
        public async Task<IActionResult> DeleteOrderByAdmin(int OrderID)
        {
            try
            {

                var listorders = await _mediator.Send(new DeleteOrderByAdmin(OrderID));
                return Ok(listorders.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Checkout")]
        public async Task<IActionResult> GetCheckoutPayment(int? id)
        {
            try
            {
                var ListofCheckoutPayment = await _mediator.Send(new GetCheckoutForPayment(id));
                return Ok(ListofCheckoutPayment.Data);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
