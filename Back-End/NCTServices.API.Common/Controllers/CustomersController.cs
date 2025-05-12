using Microsoft.AspNetCore.Mvc;
using NCTServices.Application.Common.Services.Product.Commands;
using NCTServices.Application.Common.Services.Product.Queries;
using NCTServices.Model.Requests;

namespace NCTServices.API.Common.Controllers
{
    public class CustomersController : BaseApiController<CustomersController>
    {
        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> GetCustomerByAdmin(string? searchValue, int? skip)
        {
            try
            {
                //if (!string.IsNullOrWhiteSpace(searchValue))
                //{
                //    var listProducts = await _mediator.Send(new SearchProduct(searchValue, skip));
                //    return Ok(listProducts.Data);
                //}
                //else
                //{
                //    var listProducts = await _mediator.Send(new GetAllProduct(skip));
                //    return Ok(listProducts.Data);
                //}
                return null;

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("Customers")]
        public async Task<IActionResult> GetCustomerDetailByAdmin(int Rowid)
        {
            try
            {
              
                return null;

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> AddNewCustomerByAdmin(CustomerRequest request)
        {
            try
            {
                //var listProducts = await _mediator.Send(new AddProduct(request));
                //return Ok(listProducts);

                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPut]
        [Route("Customer")]
        public async Task<IActionResult> UpdateCustomerByAdmin(CustomerRequest request)
        {
            try
            {
                //var listProducts = await _mediator.Send(new UpdateProductById(request));
                //return Ok(listProducts);

                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("Customer")]
        public async Task<IActionResult> DeleteCustomerByAdmin(int RowId)
        {
            try
            {
                //var listProducts = await _mediator.Send(new DeleteProductById(RowId));
                //return Ok(listProducts);

                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
