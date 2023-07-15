using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Tests
{
    public class DummyObject
    {
        public DummyObject(int x, int y) 
        {
            X = x; Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
