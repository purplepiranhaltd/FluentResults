using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Errors
{
    public static class ValidationErrors
    {
        public static readonly Error ValidationFailure = new($"{nameof(Error)}.{nameof(ValidationFailure)}", "Validation Failure");
    }
}
