using PurplePiranha.FluentResults.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results
{
    public static class ResultWithValidationExtensions
    {
        public static ResultWithValidation OnValidationFailure(this ResultWithValidation result, Action<IEnumerable<string>> action)
        {
            if (result.IsValidationFailure)
                action(result.ValidationFailures);

            return result;
        }


    }
}
