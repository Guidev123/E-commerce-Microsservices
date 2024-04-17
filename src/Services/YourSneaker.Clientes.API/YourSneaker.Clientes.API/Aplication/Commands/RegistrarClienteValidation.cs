using FluentValidation;



namespace YourSneaker.Clientes.API.Aplication.Commands
{
    public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id de cliente inválido.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome do cliente insuficiente.");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("Cpf inválido.");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("Email inválido.");
        }
        protected static bool TerCpfValido(string cpf)
        {
            return Core.DomainObjects.Cpf.CpfValidation(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}
