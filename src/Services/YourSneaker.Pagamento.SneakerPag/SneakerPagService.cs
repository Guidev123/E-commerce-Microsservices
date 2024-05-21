using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSneaker.Pagamento.SneakerPag
{
    public class SneakerPagService
    {
        public readonly string ApiKey;
        public readonly string EncryptionKey;

        public SneakerPagService(string apiKey, string encryptionKey)
        {
            ApiKey = apiKey;
            EncryptionKey = encryptionKey;
        }
    }
}
