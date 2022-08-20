using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NSE.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly List<string> Erros = new();

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (modelState.IsValid) return CustomResponse();

            IEnumerable<ModelError> errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (ModelError error in errors)
            {
                string message = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                Erros.Add(message);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            AdicionarErros(validationResult.Errors.Select(e => e.ErrorMessage).ToArray());

            return CustomResponse();
        }

        protected ActionResult CustomErrorResponse(params string[] erros)
        {
            if (erros == null || !erros.Any()) return CustomResponse();

            AdicionarErros(erros);

            return CustomResponse();
        }

        protected bool OperacaoValida() => !Erros.Any();

        protected bool OperacaoInvalida() => !OperacaoValida();

        protected void AdicionarErros(params string[] erros) => Erros.AddRange(erros);

        protected void LimparErros() => Erros.Clear();
    }
}
