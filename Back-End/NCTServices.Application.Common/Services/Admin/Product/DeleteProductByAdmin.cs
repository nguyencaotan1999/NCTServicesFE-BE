using Dapper;
using MediatR;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Model.Requests;
using NCTServices.Shared.Constants;
using NCTServices.Shared.Wrapper;
using System.Data;


namespace NCTServices.Application.Common.Services.Admin.Product
{
    public class DeleteProductByAdmin : IRequest<Result<bool>>
    {
        public int RowId { get; set; }
        public DeleteProductByAdmin(int rowid)
        {
            RowId = rowid;
        }

    }
    public class DeleteProductByAdminHandler : IRequestHandler<DeleteProductByAdmin, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public DeleteProductByAdminHandler(IApplicationWriteDbConnection writeDbConnection)
        {
            _sqlDbConnection = writeDbConnection;
        }
        public async Task<Result<bool>> Handle(DeleteProductByAdmin request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ProductName", request.RowId);

                var response = await _sqlDbConnection.QueryAsync<bool>(SQLConstant.DeleteProductByAdmin, CommandType.Text, parameters);
                return await Result<bool>.SuccessAsync(response);
            }
            catch (Exception)
            {
                return await Result<bool>.FailAsync("Deleted Failed");
            }
        }
    }
}
