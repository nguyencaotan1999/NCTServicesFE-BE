using MediatR;
using NCTServices.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Application.Common.Services.Admin.Order.Commands
{
    public class DeleteOrderByAdmin : IRequest<Result<bool>>
    {
        public int OrderId { get; set; }
        public DeleteOrderByAdmin(int orderID) 
        {
            OrderId = orderID;
        } 
    }
    public class DeleteOrderByAdminHanlder : IRequestHandler<DeleteOrderByAdmin, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteOrderByAdmin request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Deleted fail");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
