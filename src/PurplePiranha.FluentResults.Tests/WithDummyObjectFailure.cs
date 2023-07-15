using PurplePiranha.FluentResults.FailureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Tests
{
    public class WithDummyObjectFailure : Failure
    {
        public WithDummyObjectFailure(string code, string message, DummyObject obj) : base(code, message, obj)
        {
        }

#nullable disable
        public DummyObject DummyObject => (DummyObject)base.Obj;
#nullable enable
    }
}
