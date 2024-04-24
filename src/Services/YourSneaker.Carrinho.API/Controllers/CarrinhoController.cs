using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourSneaker.WebAPI.Core.Controllers;

namespace YourSneaker.Carrinho.API.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {

    }
}
