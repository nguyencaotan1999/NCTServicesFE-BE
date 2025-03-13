using Microsoft.AspNetCore.Mvc;
using NCTServices.Application.Common.Services.Account.Command;
using NCTServices.Application.Common.Services.Login;
using NCTServices.Application.Common.Services.OrderDetail.Queries;
using NCTServices.Domain.Entity;
using NCTServices.Model.Requests;

namespace NCTServices.API.Common.Controllers
{
    public class AccountController : BaseApiController<AccountController>
    {
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            try
            {
                if (username == null || password == null)
                {
                    return BadRequest("User Name or Password is not null");
                }

                UserRequest request = new UserRequest();
                request.UserName = username;
                request.Password = password;
                var listProducts = await _mediator.Send(new GetUserQueries(request));
               
                return Ok(listProducts);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAccount( RegisterAccoutnRequest request  )
        {
            try
            {
                if (request != null) {
                    var listProducts = await _mediator.Send(new RegisterAccountCommand(request));

                    return Ok(listProducts);
                }
                return BadRequest();

               
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
