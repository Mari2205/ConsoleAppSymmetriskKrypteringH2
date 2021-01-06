using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleAppSymmetriskKrypteringH2
{
    /// <summary>
    /// this class generates a random number with 
    /// different lengths which are used as keys
    /// </summary>
    class GenrateKey
    {
        public byte[] GenrateRandomNumber(int length)
        {
            using (RNGCryptoServiceProvider ranNoGen = new RNGCryptoServiceProvider())
            {
                byte[] ranNo = new byte[length];
                ranNoGen.GetBytes(ranNo);

                return ranNo;
            }
        }
    }
}
