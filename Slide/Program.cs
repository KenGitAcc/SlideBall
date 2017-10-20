using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide
{    
    public class Slide
    {
        public const string rootName = "root";
        public static Random random = new Random();
        public static int totalLevel;
        public static IList<GateContainer> containerList = new List<GateContainer>();
        public static GateNode<Gate> rootGate;
        public static int containerNameStart = 65;
        enum GateSwitches
        {
            GoLeft,
            GoRight
        }

        static private void CreateGateNode(GateNode<Gate> parentGate)
        {
            
            var switches = Enum.GetValues(typeof(GateSwitches));
            var level = parentGate.Level + 1;
            foreach (var switchs in switches)
            {
                if (parentGate.Level == totalLevel)
                {
                    var container = new GateContainer(((char)containerNameStart).ToString(), false, parentGate.Data.Name);
                    containerList.Add(container);
                    containerNameStart++;
                    
                }
                else
                {
                    int randomSwitches = random.Next(0, 1);
                    string gateName = level + switchs.ToString();
                    GateNode<Gate> gate = new GateNode<Gate>
                    (
                        new Gate(gateName, level, randomSwitches)
                    );
                    gate.Level = level;
                    gate.Parent = parentGate;
                    parentGate.AddChild(gate);
                    CreateGateNode(gate);
                }                
            }
            
        }
       
        static public void initalSlide()
        {
            
            int randomSwitches = random.Next(0, 1);
            rootGate = new GateNode<Gate>
            (
                new Gate(rootName, 1, randomSwitches)
            );
            rootGate.Level = 1;
            CreateGateNode(rootGate);
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine("Please enter slide level and number of balls");
                return;
            }

            int level;
            bool test = int.TryParse(args[0], out level);
            if (test == false)
            {
                System.Console.WriteLine("Please enter a numeric argument for slide level.");
                return;
            }

            totalLevel = level;

            int num;
            test = int.TryParse(args[1], out num);
            if (test == false)
            {
                System.Console.WriteLine("Please enter a numeric argument for number of balls.");
                return;
            }

            initalSlide();
        }
    }
}
