using YourSneaker.Core.Messages;



namespace YourSneaker.Clientes.API.Aplication.Commands
{
    public class RegistrarClienteCommand : Command
    {
        //Dados do construtor de cliente
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            Cpf = cpf;
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
        }
        public override bool EstaValido()
        {
            ValidationResult = new RegistrarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
