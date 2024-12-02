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

namespace NCTServices.Application.Common.Services.Account.Command
{
    public class RegisterAccountCommand : IRequest<Result<bool>>
    {
        public RegisterAccoutnRequest RegisterAccoutnRequest;
        public RegisterAccountCommand(RegisterAccoutnRequest request) 
        {
            RegisterAccoutnRequest = request;
        }
    }

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public RegisterAccountCommandHandler(IApplicationWriteDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }
        public async Task<Result<bool>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("name", request.RegisterAccoutnRequest.Name);
                    parameters.Add("email", request.RegisterAccoutnRequest.Email);
                    parameters.Add("password", request.RegisterAccoutnRequest.Password);
                    parameters.Add("CreatedDate", DateTime.Now);
                    parameters.Add("ModifiedDate", DateTime.Now);

                    var response = await _sqlDbConnection.QueryFirstOrDefaultAsync<bool>(SQLConstant.Register_Account, CommandType.Text, parameters);

                    return Result<bool>.Success("Register successfully");
                }
                return Result<bool>.Fail("Register Fail");
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
