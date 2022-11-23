using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Exceptions
{
    public class BillLadingException : ApplicationException
    {
        public BillLadingException()
        {
                
        }

        public BillLadingException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
