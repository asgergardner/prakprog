using static System.Math;
using System;
using static System.Double;

public static class Integrator{
	public static double integrate(Func<double,double> f, double a, double b, double delta=1e-6, double eps=1e-6, double f2=NaN, double f3=NaN){
		double h=b-a;
		if(IsNaN(f2)){
			f2=f(a+2*h/6);
			f3=f(a+4*h/6);	
		}

		//Assigning new points (eq. 48)
		double f1=f(a+h/6);
		double f4=f(a+5*h/6);
		
		//Integral estimates with weights (eq. 49)
		double Q=(2*f1+f2+f3+2*f4)/6*(b-a);
		double q=(f1+f2+f3+f4)/4*(b-a);
		double err=Abs(Q-q);
		
		//Recursive evaluation
		if(err<= Max(delta, eps*Abs(Q))){
			return Q; //end recursion
		}
		else{
			return integrate(f, a, (a+b)/2, delta/(Sqrt(2)), eps, f1, f2) + integrate(f, (a+b)/2, b, delta/(Sqrt(2)), eps, f3, f4);
		}
	}
}
