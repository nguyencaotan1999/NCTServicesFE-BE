using Dapper;
using MediatR;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Model.Responses;
using NCTServices.Shared.Constants;
using NCTServices.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Application.Common.Services.CheckOut.Queries
{
    public class GetCheckoutForPayment : IRequest<Result<List<CheckOutResponses>>>
    {
        public int ? UserId { get; set; }
        public GetCheckoutForPayment(int? userid) { 
            UserId = userid;
        }
    }

    public class GetCheckoutForPaymentHandler : IRequestHandler<GetCheckoutForPayment, Result<List<CheckOutResponses>>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public GetCheckoutForPaymentHandler(IApplicationWriteDbConnection writeDbConnection) { 
            _sqlDbConnection = writeDbConnection;
        }

        public async Task<Result<List<CheckOutResponses>>> Handle(GetCheckoutForPayment request, CancellationToken cancellationToken)
        {
            try
            {
                List<CheckOutResponses> responsesData = new List<CheckOutResponses>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", request.UserId);

                var response = await _sqlDbConnection.QueryAsync<CheckOutResponses>(SQLConstant.Get_Checkout_ForPayment, CommandType.Text, parameters);
                foreach (var item in response)
                {
                    responsesData.Add(item);
                }
                return await Result<List<CheckOutResponses>>.SuccessAsync(responsesData);
            }
            catch (Exception ex)
            {

                return await Result<List<CheckOutResponses>>.FailAsync();
            }
        }
    }
}
