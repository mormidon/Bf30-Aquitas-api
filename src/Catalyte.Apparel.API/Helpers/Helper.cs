using Catalyte.Apparel.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Catalyte.Apparel.API.Controllers
{
    public static class Helper
     {
         public static ActionResult ToActionResult<T>(this ProviderResponse<T> response)
         {
             return response.ResponseType switch
             {
                 ResponseTypes.Success => new OkObjectResult(response.ResponseObject),
                 ResponseTypes.NotFound => new NotFoundObjectResult(response.Message),
                 _ => new BadRequestResult()
             };
        }
    }
}
