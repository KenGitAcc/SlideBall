using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide
{
    public class Gate
    {
        public string Name;
        public int Level;
        public int Switches;

        public Gate(string name, int level, int switches)
        {
            this.Name = name;
            this.Level = level;
            this.Switches = switches;
        }
    }
}
