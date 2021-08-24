using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipLibrary
{
    public abstract class Ships
    {
        public List<string> Warship { get; set; }
        public List<string> Destroyer { get; set; }
        public List<string> Cruiser { get; set; }
        public List<string> Tanker { get; set; }
        public List<string> UBoat { get; set; }

        public bool isDeadWS { get; set; }
        public bool isDeadDS { get; set; }
        public bool isDeadCS { get; set; }
        public bool isDeadTK { get; set; }
        public bool isDeadUB { get; set; }

        
    }
}
