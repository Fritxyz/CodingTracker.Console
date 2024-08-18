using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    internal class Validations
    {
        internal bool DateTimeValidations(DateTime startTime,  DateTime endTime) => startTime<endTime && endTime> startTime;

    }
}
