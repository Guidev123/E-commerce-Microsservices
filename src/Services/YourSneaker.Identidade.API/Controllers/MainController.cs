using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YourSneaker.Identidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();  
        protected ActionResult CustomResponse(object result = null)
        {
            if (!ValidOperation()) return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> 
            {
                {"Messages", Errors.ToArray() },
            }));

            return Ok(result);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState) 
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach ( var error in errors) 
            {
                AddProcessError(error.ErrorMessage);
            }

            return CustomResponse();
        }



        protected bool ValidOperation() 
        {
            return !Errors.Any();
        }

        protected void AddProcessError(string error) 
        {
            Errors.Add(error);    
        }

        protected void ClearProcessError() 
        {
            Errors.Clear();
        }
    }
}
