using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Exception
{
    public class SMSException:ApplicationException
    {
        public SMSException():base()
        {

        }
        public SMSException(string msg): base(msg)
        {

        }
    }
}
