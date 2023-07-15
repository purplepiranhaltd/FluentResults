using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.FailureTypes
{
    public sealed class NoFailure : Failure
    {
        internal NoFailure() : base(string.Empty, string.Empty)
        {
        }
    }
}
