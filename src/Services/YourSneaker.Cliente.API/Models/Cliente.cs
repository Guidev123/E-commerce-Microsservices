using YourSneaker.Core.DomainObjects;

namespace YourSneaker.Cliente.API.Models
{
    public class Cliente : Entity, IAggregrateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }


        //ENITY FRAMEWORK RELATION
        protected Cliente()
        {
            
        }


        public Cliente(string nome, string email, string cpf, bool excluido)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Excluido = false;
        }
    }
}
