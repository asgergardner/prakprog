using static System.Math;
using static System.Console;
using System;
using System.Collections.Generic;

class main{
	public static void Main(){
		double b=0.25;
		double c=5;
		Func<double, vector, vector> intfunc = delegate(double t, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega -c*Sin(theta));
		};
		double init = 0;
		double end = 10;
		vector ya = new vector(PI-0.1, 0.0);
		var xlist = new List<double>();
		var ylist = new List<vector>();
		
		vector int_ = ode.ivp(intfunc, init, ya, end, xlist, ylist);

		for(int i = 0; i < xlist.Count; i++){
			WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
		}
	}
}
