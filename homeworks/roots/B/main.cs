using static System.Console;
using static roots;
using static rk45;
using System;

class main{
	public static void Main(){
		double rmin; double rmax;
		
		for(rmax=1.0; rmax<=8; rmax+=1.0/32){	
			rmin = 1e-6;
			vector f0 = new double[] {rmin-rmin*rmin, 1-2*rmin};	
			Func<vector,vector> M = delegate(vector eps){
				Func<double,vector,vector> radialeq = delegate(double r, vector y){
						double f = y[0];
						double fp = y[1];
						vector res = new vector(2);
						res[0] = fp;
						res[1] = -2*f*(eps[0]+1.0/r);
						return res;
					};
				vector sol = rk45.driver(radialeq, rmin, rmax, f0);
				vector out_ = new double[] {sol[0]};	
				return out_;
			};
			
			vector init = new double[] {-1};
			vector root = nroots(M,init);
			double tableSol = -0.5;
			WriteLine($"{rmax} {root[0]} {tableSol}");
		}
	
		//creating new index	
		WriteLine("\n");

		for(rmin=0.5; rmin>1e-6; rmin-=1.0/64){
			rmax = 8;	
			vector f0 = new double[] {rmin-rmin*rmin, 1-2*rmin};	
			Func<vector,vector> M = delegate(vector eps){
				Func<double,vector,vector> radialeq = delegate(double r, vector y){
						double f = y[0];
						double fp = y[1];
						vector res = new vector(2);
						res[0] = fp;
						res[1] = -2*f*(eps[0]+1.0/r);
						return res;
					};
				vector sol = rk45.driver(radialeq, rmin, rmax, f0);
				vector out_ = new double[] {sol[0]};	
				return out_;
			};
			
			vector init = new double[] {-1};
			vector root = nroots(M,init);
			double tableSol = -0.5;
			WriteLine($"{rmin} {root[0]} {tableSol}");
		}
	}
}
