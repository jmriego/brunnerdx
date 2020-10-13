/***
 * IIR Filter Library - Implementation
 *
 * Copyright (C) 2016  Martin Vincent Bloedorn
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License version 3, as
 * published by the Free Software Foundation.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

#include "filters.h"

using namespace IIR;

// CONSTRUCTOR AND DESTRUCTOR * * * * * * * * * * * * * * *

Filter::Filter(float_t hz_, float_t ts_, ORDER od_, TYPE ty_) :
  ts( ts_ ),
  hz( hz_ ),
  od( od_ ),
  ty( ty_ )
{
  init();
}

Filter::~Filter() { }

// PUBLIC METHODS * * * * * * * * * * * * * * * * * * * * *

void Filter::init(bool doFlush) {
  if(doFlush) flush();
  f_err  = false;
  f_warn = false;

  initLowPass();
}

float_t Filter::filterIn(float input) {
  if(f_err) return 0.0;
  return computeLowPass(input);

}

void Filter::flush() {
  for(uint8_t i=0; i<MAX_ORDER; i++) {
    u[i] = 0.0;
    y[i] = 0.0;
  }
}


// PRIVATE METHODS  * * * * * * * * * * * * * * * * * * * *

inline float_t Filter::computeLowPass(float_t input) {
  for(uint8_t i=MAX_ORDER-1; i>0; i--) {
    y[i] = y[i-1];
    u[i] = u[i-1];
  }

  switch((uint8_t)od) {
    case (uint8_t)ORDER::OD1:
        y[0] = k1*y[1] + k0*input;
      break;
    case (uint8_t)ORDER::OD2:
        y[0] = k1*y[1] - k2*y[2] + (k0*input)/KM;
      break;
    case (uint8_t)ORDER::OD3:
        y[0] = k1*y[1] - k2*y[2] + k3*y[3] + (k0*input)/KM;
      break;
    case (uint8_t)ORDER::OD4:
        y[0] = k1*y[1] - k2*y[2] + k3*y[3] - k4*y[4] + (k0*input)/KM;
      break;
    default:
        y[0] = input;
      break;
  }
  return y[0];
}

inline void  Filter::initLowPass() {
  switch((uint8_t)od) {
    case (uint8_t)ORDER::OD1:
        a  = 2.0*PI*hz;
        k1 = exp(-a*ts);
        k0 = 1.0 - k1;
      break;
    case (uint8_t)ORDER::OD2:
        a  = -PI*hz*SQRT2;
        b  =  PI*hz*SQRT2;
        k2 = ap(exp(2.0*ts*a));
        k1 = ap(2.0*exp(a*ts)*cos(b*ts));
        k0 = ap(1.0*KM - k1*KM + k2*KM);
      break;
    case (uint8_t)ORDER::OD3:
        a  = -PI*hz;
        b  =  PI*hz*SQRT3;
        c  =  2.0*PI*hz;
        b3 = exp(-c*ts);
        b2 = exp(2.0*ts*a);
        b1 = 2.0*exp(a*ts)*cos(b*ts);
        k3 = ap(b2*b3);
        k2 = ap(b2 + b1*b3);
        k1 = ap(b1 + b3);
        k0 = ap(1.0*KM - b1*KM + b2*KM -b3*KM + b1*KM*b3 - b2*KM*b3);
      break;
    case (uint8_t)ORDER::OD4:
        a  = -0.3827*2.0*PI*hz;
        b  =  0.9238*2.0*PI*hz;
        c  = -0.9238*2.0*PI*hz;
        d  =  0.3827*2.0*PI*hz;
        b4 = exp(2.0*ts*c);
        b3 = 2.0*exp(c*ts)*cos(d*ts);
        b2 = exp(2.0*ts*a);
        b1 = 2.0*exp(a*ts)*cos(b*ts);
        k4 = ap(b2*b4);
        k3 = ap(b1*b4 + b2*b3);
        k2 = ap(b4 + b1*b3 + b2);
        k1 = ap(b1 + b3);
        k0 = ap(1.0*KM - k1*KM + k2*KM - k3*KM + k4*KM);
      break;
  }
}


float_t Filter::ap(float_t p) {
  f_err  = f_err  | (abs(p) <= EPSILON );
  f_warn = f_warn | (abs(p) <= WEPSILON);
  return (f_err) ? 0.0 : p;
}

