using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;

namespace MobilyaETicaret.API.Controllers
{
    public class BaseController : Controller
    {
        [Route("api/[Controller]")]
        [NonAction]
        public IActionResult SelectResponseResult<TEntity>(APIResponseDTO<TEntity> responseDTO)
        {


            switch (responseDTO.StatuCode)
            {
                case 204:

                    return new ObjectResult(null)
                    {
                        StatusCode = responseDTO.StatuCode
                    };

                default:
                    return new ObjectResult(responseDTO)
                    {
                        StatusCode = responseDTO.StatuCode

                    };
            }
        }
        [NonAction]
        public IActionResult ResultAPI<TEntity>(TEntity tEntity)
        {
            try
            {
                if (tEntity != null)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Success(200, tEntity));
                }

                else if (tEntity == null)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(APIResponseDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(APIResponseDTO<TEntity>.Success(204, tEntity));
            }
        }

        [NonAction]
        public IActionResult ResultAPI<TEntity>(List<TEntity> tEntity)
        {
            try
            {
                if (tEntity.Count > 0)
                {
                    return SelectResponseResult(APIResponseDTO<List<TEntity>>.Success(200, tEntity));
                }

                else if (tEntity.Count == 0)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(APIResponseDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(APIResponseDTO<List<TEntity>>.Success(204, tEntity));
            }
        }
    }
}
