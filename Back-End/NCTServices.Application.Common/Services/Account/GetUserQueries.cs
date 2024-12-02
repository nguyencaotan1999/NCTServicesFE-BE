using Dapper;
using MediatR;
using NCTServices.Contracts.Interfaces.Responsitories;
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

namespace NCTServices.Application.Common.Services.Login
{
    public class GetUserQueries : IRequest<Result<UserResponses>>
    {
        public UserRequest UserRequest { get; set; }
        public GetUserQueries(UserRequest user) 
        {
            UserRequest = user;
        }
    }
    public class GetUserQueriesHandler : IRequestHandler<GetUserQueries, Result<UserResponses>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public GetUserQueriesHandler(IApplicationWriteDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }
        public async Task<Result<UserResponses>> Handle(GetUserQueries request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", request.UserRequest.UserName);

                var response = await _sqlDbConnection.QueryFirstOrDefaultAsync<UserResponses>(SQLConstant.Get_User, CommandType.Text, parameters);

                if (response != null)
                {
                    if (request.UserRequest.Password == response.Password)
                    {
                        return Result<UserResponses>.Success(response);
                    }
                    else
                    {
                        return Result<UserResponses>.Success("Password is not valid");
                    }
                    
                }
                else
                {
                    return Result<UserResponses>.Success("User is not exists");
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
          
        }
    }
}
