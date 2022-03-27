using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunnerDX.Mapping
{
    public class ButtonMapping
    {
        public int decTrimX;
        public int incTrimX;
        public int decTrimY;
        public int incTrimY;
        public int decTrimZ;
        public int incTrimZ;

        public ButtonMapping(int decTrimX=-1, int incTrimX=-1, int decTrimY=-1, int incTrimY=-1, int decTrimZ=-1, int incTrimZ=-1)
        {
            this.decTrimX = decTrimX;
            this.incTrimX = incTrimX;
            this.decTrimY = decTrimY;
            this.incTrimY = incTrimY;
            this.decTrimZ = decTrimZ;
            this.incTrimZ = incTrimZ;
        }
    }
}
