using System;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class ETokenNotFound : Exception
    {
        public ETokenNotFound(string token) : base("Token '" + token + "' not found.") { }
    }
}