using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local.defpub.TicketPrintServer.Exceptions
{
    class UnknownMessageException : Exception
    {
        public UnknownMessageException()
        {
        }

        public UnknownMessageException(string message) : base(message)
        {

        }
    
        public UnknownMessageException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
