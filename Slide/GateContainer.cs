using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide
{
    public class GateContainer
    {
        public string Name;
        public bool HasBall;
        public string GateName;

        public GateContainer(string name, bool hasBall, string gateName)
        {
            this.Name = name;
            this.HasBall = hasBall;
            this.GateName = gateName;
        }
    }
}
