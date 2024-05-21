using System.Security.Cryptography;
using System.Text;

namespace YourSneaker.Pagamento.SneakerPag
{
    public class CardHash
    {
        public CardHash(SneakerPagService snekaerPagService)
        {
            SneakerPagService = snekaerPagService;
        }

        private readonly SneakerPagService SneakerPagService;

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardCvv { get; set; }


        // SIMULACAO DE CRIPTOGRAFIA GATEWAY
        public string Generate()
        {
            using var aesAlg = Aes.Create();

            aesAlg.IV = Encoding.Default.GetBytes(SneakerPagService.EncryptionKey);
            aesAlg.Key = Encoding.Default.GetBytes(SneakerPagService.ApiKey);

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(CardHolderName + CardNumber + CardExpirationDate + CardCvv);
            }

            return Encoding.ASCII.GetString(msEncrypt.ToArray());
        }
    }
}
