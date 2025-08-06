using System;
using System.Drawing;

namespace SAM.Core.Python
{
    public class Input : Variable
    {
        public Input(string name, bool value)
            : base(name, value)
        {

        }

        public Input(string name, Color value)
            : base(name, value)
        {

        }

        public Input(string name, DateTime value)
            : base(name, value)
        {

        }

        public Input(string name, double value)
            : base(name, value)
        {

        }

        public Input(string name, string value)
            : base(name, value)
        {

        }


    }
}
