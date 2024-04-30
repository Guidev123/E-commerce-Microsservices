using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using YourSneaker.Core.Comunication;

namespace YourSneaker.WebAPI.Core.Controllers
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
            foreach (var error in errors)
            {
                AddProcessError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddProcessError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponsePossuiErros(response);
            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            foreach (var message in response.Errors.Messages)
            {
                AddProcessError(message);
            }

            return true;
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
