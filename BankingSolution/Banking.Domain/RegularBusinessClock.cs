using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain
{
    public class RegularBusinessClock : IProvideTheBusinessClock
    {
        public bool IsDuringBusinessHours()
        {
            throw new NotImplementedException();
        }
    }
}
