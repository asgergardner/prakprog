using static System.Math;
using static System.Console;
using System.Collections.Generic;
using System;

class main{
	public static void Main(){
		rk45 rk45solver = new rk45();
		
		Func<double,vector,vector> f = delegate(double t, vector y){
			double b_ = 0.25;
			double c_ = 5.0;
                        double theta = y[0];
                        double omega = y[1];
                        return new vector(omega, -b_*omega -c_*Sin(theta));
		};

		double a = 0.0;
		double b = 10.0;
		double[] init = new double[] {PI-0.1, 0.0};
		vector ya = new vector(init);
		List<double> xlist = new List<double>();
		List<vector> ylist = new List<vector>();
		double acc = 1e-8;
		double eps = 1e-8;
	       	double h = 0.01;	
		vector yEnd = rk45solver.driver(f, a, b, ya, xlist, ylist, h, acc, eps);

		for(int i=0; i<xlist.Count; i++){
			WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
		}
	}
}
