using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunnerDX.Helpers
{
    internal class Ratio
    {
        private double multiplier;

        public Ratio(double multiplier)
        {
            this.multiplier = multiplier;
        }

        public int pct
        {
            get
            {
                return (int)Math.Round(multiplier * 100.0);
            }
            set
            {
                this.multiplier = Math.Round(value / 100.0);

            }
        }

        public static implicit operator Ratio(double value) {
            return new Ratio(value);
        }

        public static implicit operator double(Ratio r) {
            return r.multiplier;
        }
    }
}
