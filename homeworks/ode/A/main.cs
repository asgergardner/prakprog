using static System.Math;
using static System.Console;
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
		double[] init = new double[] {PI-0.1, 0.0};
		vector ya = new vector(init);
		double step = 1.0/16;
		for(double x=step; x<=10; x+=step){
			vector yEnd = rk45solver.driver(f, x-step, x, ya);
			WriteLine($"{x} {yEnd[0]} {yEnd[1]}");
			ya = yEnd;
		}
	}
}
