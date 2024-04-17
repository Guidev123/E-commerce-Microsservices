using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YourSneaker.WebApp.MVC.Extensions;

namespace YourSneaker.WebApp.MVC.Models
{
    public class UsuarioViewModel
    {
        public class UsuarioRegistro
        {

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [DisplayName("Nome completo")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [DisplayName("CPF")]
            [Cpf]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} foi digitado em formato inválido")]
            public string Email { get; set; }


            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} foi digitado em formato inválido", MinimumLength = 6)]
            public string Senha { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [Display(Name ="Confirmar Senha")]
            [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
            public string SenhaConfirma { get; set; }
        }

        public class UsuarioLogin
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} foi digitado em formato inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} foi digitado em formato inválido", MinimumLength = 6)]
            public string Senha { get; set; }
        }


        public class UsuarioRespostaLogin
        {
            public string AccessToken { get; set; }
            public double ExpiresIn { get; set; }
            public UsuarioToken UsuarioToken { get; set; }
            //public ErrorViewModel ResponseResult { get; set; }
            public ResponseResult ResponseResult { get; set; }
        }

        public class UsuarioToken
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public IEnumerable<UsuarioClaim> Claims { get; set; }
        }

        public class UsuarioClaim
        {
            public string Value { get; set; }
            public string Type { get; set; }
        }
    }
}
