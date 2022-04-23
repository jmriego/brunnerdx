using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunnerDX.Filters
{
    class LowPassFilter
    {
        private double output;
        private double ePow;

        public LowPassFilter(double iCutOffFrequency, double iDeltaTime)
        {
            this.output = 0.0;
            this.ePow = 1.0 - Math.Pow(Math.E, -iDeltaTime * 2 * Math.PI * iCutOffFrequency);
        }

        public double Update(double input)
        {
            this.output += (input - this.output) * this.ePow;
            return this.output;
        }

    }
}
