using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Demo.Infrastructure.Ioc
{
    public class SigningConfig
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfig()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
                
        }
    }
}