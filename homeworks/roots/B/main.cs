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
		
		WriteLine("\n");

		double eps_; double acc;
		for(eps_=0.01; eps_>1e-12; eps_-=5e-5){
			rmin=1e-6;
			rmax=8;
			acc=0.001;
			Func<vector,vector> M = delegate(vector eps){
                                Func<double,vector,vector> radialeq = delegate(double r, vector y){
                                                double f = y[0];
                                                double fp = y[1];
                                                vector res = new vector(2);
                                                res[0] = fp;
                                                res[1] = -2*f*(eps[0]+1.0/r);
                                                return res;
                                        };
				vector f0 = new double[] {rmin-rmin*rmin, 1-2*rmin};
				vector sol = rk45.driver(radialeq, rmin, rmax, f0, null, null, 0.01, acc, eps_);
				vector out_ = new double[] {sol[0]};
				return out_;
			};

			vector init = new double[] {-1};
                        vector root = nroots(M,init);
                        double tableSol = -0.5;
                        WriteLine($"{eps_} {root[0]} {tableSol}");
		}

		WriteLine("\n");

		for(acc=0.01; acc>1e-12; acc-=5e-5){
                        rmin=1e-6;
                        rmax=8;
                        eps_=0.01;
                        Func<vector,vector> M = delegate(vector eps){
                                Func<double,vector,vector> radialeq = delegate(double r, vector y){
                                                double f = y[0];
                                                double fp = y[1];
                                                vector res = new vector(2);
                                                res[0] = fp;
                                                res[1] = -2*f*(eps[0]+1.0/r);
                                                return res;
                                        };
                                vector f0 = new double[] {rmin-rmin*rmin, 1-2*rmin};
                                vector sol = rk45.driver(radialeq, rmin, rmax, f0, null, null, 0.01, acc, eps_);
                                vector out_ = new double[] {sol[0]};
                                return out_;
                        };

                        vector init = new double[] {-1};
                        vector root = nroots(M,init);
                        double tableSol = -0.5;
                        WriteLine($"{acc} {root[0]} {tableSol}");
                }
	}
}
