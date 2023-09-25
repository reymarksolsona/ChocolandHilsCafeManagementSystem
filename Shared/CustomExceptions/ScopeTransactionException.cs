using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CustomExceptions
{
    [Serializable]
    public class ScopeTransactionException : Exception
    {
        public ScopeTransactionException()
        {

        }

        public ScopeTransactionException(string errors) : base(String.Format("Scop transaction fail: {0}", errors))
        {

        }
    }
}
