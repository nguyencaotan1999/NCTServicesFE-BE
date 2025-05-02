using MediatR;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Application.Common.Services.Admin.Order.Commands
{
    public class CreateOrderByAdmin : IRequest<Result<bool>>
    {
        public CreateOrderByAdmin()
        { }
    }

    public class CreateOrderByAdminHandler : IRequestHandler<CreateOrderByAdmin, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public CreateOrderByAdminHandler(IApplicationWriteDbConnection sqlDBconnection) {
            _sqlDbConnection = sqlDBconnection;
        }
        public async Task<Result<bool>> Handle(CreateOrderByAdmin request, CancellationToken cancellationToken)
        {

            try
            {
                return await Result<bool>.SuccessAsync(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
