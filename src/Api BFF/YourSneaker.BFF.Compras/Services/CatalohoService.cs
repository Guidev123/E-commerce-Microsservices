﻿using Microsoft.Extensions.Options;
using YourSneaker.BFF.Compras.Extensions;

namespace YourSneaker.BFF.Compras.Services
{
    public interface ICatalogoService
    {
    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }
    }
}
