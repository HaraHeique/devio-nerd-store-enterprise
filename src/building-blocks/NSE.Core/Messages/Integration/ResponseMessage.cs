using FluentValidation.Results;

namespace NSE.Core.Messages.Integration
{
    /// <summary>
    /// Classe utilizada para retornar a validação da mensagem de integração. Ela atua como o REPLY do padrão RESPONSE/REPLY.
    /// </summary>
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; private set; }
        
        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
