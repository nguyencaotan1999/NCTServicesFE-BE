using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Domain.Entity;
using NCTServices.Model.Requests;
using NCTServices.Model.Responses;
using NCTServices.Shared.Constants;
using NCTServices.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Application.Common.Services.OrderDetail.Commands
{
    public class UpdateOrderDetailCommands : IRequest<Result<bool>>
    {
        public List<OrderDetailRequest> orderDetailRequest { get; set; }
        public UpdateOrderDetailCommands(List<OrderDetailRequest> request)
        {
            orderDetailRequest = request;
        }
    }
    public class AddOrUpdateOrderDetailCommandsHandler : IRequestHandler<UpdateOrderDetailCommands, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        private readonly IUnitOfWork _unitOfWork;
        public AddOrUpdateOrderDetailCommandsHandler(IApplicationWriteDbConnection sqlDbConnection, IUnitOfWork unitOfWork)
        {
            _sqlDbConnection = sqlDbConnection;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(UpdateOrderDetailCommands request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.orderDetailRequest.Count() > 0)
                {
                    DynamicParameters parameters = new DynamicParameters(); 
                    foreach (var item in request.orderDetailRequest)
                    {
                        parameters.Add("OrderDetailId", item.OrderDetailId);
                        parameters.Add("Quantity", item.Quantity);
                        await _sqlDbConnection.QueryFirstOrDefaultAsync<bool>(SQLConstant.Update_ORDERDETAIL, CommandType.Text,parameters);
                    }
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync();
            }
            catch (Exception)
            {
                return await Result<bool>.FailAsync();
            }
        }
    }
}
