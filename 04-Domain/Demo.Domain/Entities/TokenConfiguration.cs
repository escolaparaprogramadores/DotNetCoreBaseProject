using System;

namespace Demo.Domain.Entities
{
 public class TokenConfiguration
    {
        public string Audience { get;  set; }
        public string Issuer { get;  set; }
        public int Seconds { get;  set; }
    }
}