using MediatR;
using NCTServices.Domain.Entity;
using NCTServices.Model.Requests;
using NCTServices.Shared.Wrapper;

namespace NCTServices.Application.Common.Services.Admin.Order.Commands
{
    public class UpdateOrderByAdmin : IRequest<Result<bool>>
    {
        public OrderRequest OrderRequest { get; set; }
        public UpdateOrderByAdmin(OrderRequest request)
        {
            OrderRequest = request;
        }
    }

    public class UpdateOrderByAdminHandler : IRequestHandler<UpdateOrderByAdmin, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateOrderByAdmin request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Updated fail");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
