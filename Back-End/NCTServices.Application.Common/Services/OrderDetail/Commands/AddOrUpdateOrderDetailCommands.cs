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
    public class AddOrUpdateOrderDetailCommands : IRequest<Result<bool>>
    {
        public OrderDetailRequest orderDetailRequest { get; set; }
        public AddOrUpdateOrderDetailCommands(OrderDetailRequest request)
        {
            orderDetailRequest = request;
        }
    }
    public class AddOrUpdateOrderDetailCommandsHandler : IRequestHandler<AddOrUpdateOrderDetailCommands, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        private readonly IUnitOfWork _unitOfWork;
        public AddOrUpdateOrderDetailCommandsHandler(IApplicationWriteDbConnection sqlDbConnection, IUnitOfWork unitOfWork)
        {
            _sqlDbConnection = sqlDbConnection;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(AddOrUpdateOrderDetailCommands request, CancellationToken cancellationToken)
        {
            try
            {
                bool exitsOrder = false;
                var orderOfUser = await _unitOfWork.Repository<Orders>().Entities.Where(X => X.UserId == request.orderDetailRequest.UserId).FirstOrDefaultAsync();
                if (orderOfUser != null)
                {
                    exitsOrder = true;
                }
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", request.orderDetailRequest.UserId);
                parameters.Add("ProductId", request.orderDetailRequest.ProductId);
                parameters.Add("Quantity", request.orderDetailRequest.Quantity);
                parameters.Add("UnitPrice", request.orderDetailRequest.UnitPrice);
                parameters.Add("Subtotal", request.orderDetailRequest.Subtotal);
                parameters.Add("ModifiedDate", DateTime.Now);
                parameters.Add("ModifiedBy", 1);
                parameters.Add("CreatedDate", DateTime.Now);
                parameters.Add("CreatedBy", 1);


                if (exitsOrder)
                {
                    parameters.Add("OrderId", orderOfUser.RowId);
                    await _sqlDbConnection.QueryAsync<OrderDetails>(SQLConstant.ADD_ORDERDETAIL, CommandType.Text, parameters);
                }
                else
                {
                    var DateTimes = DateTime.Now;
                    parameters.Add("OrderDate", DateTimes);
                    parameters.Add("Status", "Okay");
                    parameters.Add("TotalAmount", request.orderDetailRequest.Quantity);
                    await _sqlDbConnection.QueryFirstOrDefaultAsync<Orders>(SQLConstant.ADD_ORDER, CommandType.Text, parameters);
                    var result = await _unitOfWork.Repository<Orders>().Entities.Where(X => X.OrderDate.Date == DateTimes.Date).FirstOrDefaultAsync();
                    parameters.Add("OrderId", result.RowId);
                    await _sqlDbConnection.QueryAsync<OrderDetails>(SQLConstant.ADD_ORDERDETAIL, CommandType.Text, parameters);
                }
                return await Result<bool>.SuccessAsync(true);
            }
            catch (Exception)
            {
                return await Result<bool>.FailAsync();
            }
        }
    }
}
