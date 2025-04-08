using Microsoft.AspNetCore.Mvc;
using NCTServices.Application.Common.Services.Product.Commands;
using NCTServices.Application.Common.Services.Product.Queries;
using NCTServices.Model.Requests;
using Microsoft.Extensions.Caching.Memory;
using NCTServices.Model.Responses;


namespace NCTServices.API.Common.Controllers
{
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IMemoryCache _cache;
        public ProductController(IMemoryCache cache) 
        {
            _cache = cache;
        }


        [HttpGet]
        [Route("ProductById")]
        public async Task<IActionResult> GetProductById(int Rowid)
        {
            try
            {
                var GetValueCache = _cache.TryGetValue(Rowid, out ProductResponses? responses);
                if (!GetValueCache)
                {
                    // Xử lý khi không tìm thấy trong cache
                    var listProducts = await _mediator.Send(new GetProductById(Rowid));

                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                    };
                    _cache.Set(Rowid, listProducts, cacheEntryOptions);
                    return Ok(listProducts); 
                }
                    return Ok(GetValueCache);
                    
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }

        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> GetProducts(string? searchValue, int? skip)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    var listProducts = await _mediator.Send(new SearchProduct(searchValue, skip));
                    return Ok(listProducts.Data);
                }
                else
                {
                    var listProducts = await _mediator.Send(new GetAllProduct(skip));
                    return Ok(listProducts.Data);
                }
               
            }
            catch (Exception)
            {
                return BadRequest();            }
            
        }
        [HttpPost]
        [Route("Product")]
        public async Task<IActionResult> AddNewProduct(ProductRequest request)
        {
            try
            {
                var listProducts = await _mediator.Send(new AddProduct(request));
                return Ok(listProducts);
            }
            catch (Exception)
            {
                return BadRequest();            }

        }
        [HttpPut]
        [Route("Product")]
        public async Task<IActionResult> UpdateProductsById(ProductRequest request)
        {
            try
            {
                var listProducts = await _mediator.Send(new UpdateProductById(request));
                return Ok(listProducts);
            }
            catch (Exception)
            {
                return BadRequest();            }

        }
        [HttpDelete]
        [Route("Product")]
        public async Task<IActionResult> DeleteProductsById(int RowId)
        {
            try
            {
                var listProducts = await _mediator.Send(new DeleteProductById(RowId));
                return Ok(listProducts);
            }
            catch (Exception)
            {
                return BadRequest();            }

        }
    }
}
