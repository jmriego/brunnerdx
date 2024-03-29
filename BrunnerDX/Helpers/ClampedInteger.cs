﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunnerDX.Helpers
{
    public class ClampedInteger
    {
        protected int min = 0;
        protected int max = 0;
        private int _value = 0;

        public ClampedInteger()
        {
        }

        public ClampedInteger(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public ClampedInteger(int min, int max, int value)
        {
            this.min = min;
            this.max = max;
            this.value = value;
        }

        public int value {
            get
            {
                return this._value;
            }
            set
            {
                this._value = (value > this.max ? this.max : value) < this.min ? this.min : value;
            }
        }

        public double ratio
        {
            // Value between -1.0 and 1.0 marking where the value is between the min and max
            get
            {
                double oldRange = this.max - this.min;
                double ratio = ((double)this.value - (double)this.min) / oldRange;
                return (ratio - 0.5) * 2.0;
            }
            set
            {
                // we can also convert from a ratio to the right value
                int oldRange = this.max - this.min;
                int center = this.min + (oldRange / 2);
                this.value = center + (int)(oldRange * (value / 2.0));
            }
        }

        public static implicit operator int(ClampedInteger i) {
            return i._value;
        }
    }

    public class PositionValue: ClampedInteger
    {
        public PositionValue(): base()
        {
            this.min = -32767;
            this.max = 32767;
        }

        public static implicit operator PositionValue(int value) {
            PositionValue result = new PositionValue();
            result.value = value;
            return result;
        }
        public static PositionValue operator -(PositionValue a, int b)
        {
            PositionValue x = (PositionValue)(a.value - b);
            return x;
        }
        public static PositionValue operator +(PositionValue a, int b)
        {
            return (PositionValue)(a.value + b);
        }
    }

    public class ForceValue: ClampedInteger
    {
        public ForceValue(): base()
        {
            this.min = -10000;
            this.max = 10000;
        }

        public static implicit operator ForceValue(int value) {
            ForceValue result = new ForceValue();
            result.value = value;
            return result;
        }
        public static ForceValue operator +(ForceValue a, ForceValue b)
        {
            return (ForceValue)(a.value + b.value);
        }
        public static ForceValue operator *(ForceValue a, double d)
        {
            return (ForceValue)(a.value * d);
        }
    }

}
