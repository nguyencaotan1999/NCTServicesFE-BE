using MediatR;
using NCTServices.Shared.Wrapper;
using NCTServices.Model.Responses;
using Dapper;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Shared.Constants;
using System.Data;

namespace NCTServices.Application.Common.Services.Order.Queries
{
    public class GetAllOrder : IRequest<Result<List<GetAllOrderByIDResponse>>>
    {
        public int Id { get; set; }
        public GetAllOrder(int id)
        { 
            Id = id;
        }
    }
    public class GetAllOrderHandler : IRequestHandler<GetAllOrder, Result<List<GetAllOrderByIDResponse>>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public GetAllOrderHandler(IApplicationWriteDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }
        public async Task<Result<List<GetAllOrderByIDResponse>>> Handle(GetAllOrder request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", request.Id);

                var response = await _sqlDbConnection.QueryAsync<GetAllOrderByIDResponse>(SQLConstant.GET_ALL_ORDER_BY_USER, CommandType.Text, parameters);
                List<GetAllOrderByIDResponse> responsesValue = new List<GetAllOrderByIDResponse>();
                responsesValue = response.ToList();
                return await Result<List<GetAllOrderByIDResponse>>.SuccessAsync(responsesValue);
            }
            catch (Exception ex)
            {

                return await Result<List<GetAllOrderByIDResponse>>.FailAsync(ex.Message);
            }       
        }
    }
}
