using Dapper;
using MediatR;
using NCTServices.Contracts.Interfaces.Responsitories;
using NCTServices.Model.Requests;
using NCTServices.Shared.Constants;
using NCTServices.Shared.Wrapper;
using System.Data;


namespace NCTServices.Application.Common.Services.Admin.Product
{
    public class UpdateProductByAdmin : IRequest<Result<bool>>
    {
        public ProductRequest ProductRequest { get; set; }
        public UpdateProductByAdmin(ProductRequest product)
        {
            ProductRequest = product;
        }

    }
    public class UpdateProductByAdminHandler : IRequestHandler<UpdateProductByAdmin, Result<bool>>
    {
        private readonly IApplicationWriteDbConnection _sqlDbConnection;
        public UpdateProductByAdminHandler(IApplicationWriteDbConnection writeDbConnection)
        {
            _sqlDbConnection = writeDbConnection;
        }
        public async Task<Result<bool>> Handle(UpdateProductByAdmin request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ProductName", request.ProductRequest.ProductName);
                parameters.Add("Brand", request.ProductRequest.Branch);
                parameters.Add("Volume", request.ProductRequest.Volumn);
                parameters.Add("Color", request.ProductRequest.Color);
                parameters.Add("Price", request.ProductRequest.Price);
                parameters.Add("Description", request.ProductRequest.ProductDescription);
                parameters.Add("Image", request.ProductRequest.Image);
                parameters.Add("StockQuantity", request.ProductRequest.StockQuantity);
                parameters.Add("CategoryID", request.ProductRequest.CategoryID);
                parameters.Add("CreatedBy", "Admin");
                parameters.Add("CreatedDate", DateTime.Now);
                parameters.Add("ModifiedBy", "Admin");
                parameters.Add("ModifiedDate", DateTime.Now);

                var response = await _sqlDbConnection.QueryAsync<bool>(SQLConstant.UpdateProductByAdmin, CommandType.Text, parameters);
                return await Result<bool>.SuccessAsync(response);
            }
            catch (Exception)
            {
                return await Result<bool>.FailAsync("Updated Failed");
            }
        }
    }
}
