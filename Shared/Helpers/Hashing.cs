using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class Hashing
    {
        public string GetSHA512String(string text)
        {
			string hashStr = "";

			byte[] byteSourceText = Encoding.ASCII.GetBytes(text);

			var SHA512Hast = new SHA512CryptoServiceProvider();

			byte[] byteHash = SHA512Hast.ComputeHash(byteSourceText);

			foreach (byte b in byteHash)
			{
				hashStr += b.ToString("x2");
			}

			return hashStr;
		}
    }
}
