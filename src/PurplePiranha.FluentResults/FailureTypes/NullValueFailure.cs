using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.FailureTypes
{
    public class NullValueFailure : Failure
    {
        public NullValueFailure() : base($"{nameof(Failure)}.{nameof(FailureTypes.NullValueFailure)}", "The specified result value is null.")
        {
        }
    }
}
