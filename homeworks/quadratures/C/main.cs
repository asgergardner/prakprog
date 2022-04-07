using static Integrator;
using static System.Math;
using static System.Console;
using static System.Double;
using System;

class main{
	public static void Main(){
		int i=0;
		int j=0;
		int k=0;

		Func<double,double> InvxSq = x => {i++; return 1/(x*x);};
		Func<double,double> Gauss = x => {j++; return x*Exp(-x*x);};	
		Func<double,double> InvxPlusSq = x => {k++; return 1/(1+x*x);};

		(double invxSqInt, double invxSqErr) = integrate(InvxSq, 1, Double.PositiveInfinity);
		(double gaussInt, double gaussErr) = integrate(Gauss, Double.NegativeInfinity, Double.PositiveInfinity);
		(double invxPlusSqInt, double invxPlusSqErr) = integrate(InvxPlusSq, Double.NegativeInfinity, 0);
		WriteLine($"1/x^2 from 1 to inf: {invxSqInt}, error: {invxSqErr}, iterations: {i++}");
		WriteLine($"x*e^-x^2 from -inf to inf: {gaussInt}, error: {gaussErr}, iterations {j++}");
		WriteLine($"1/(1+x^2) from -inf to 0: {invxPlusSqInt}, error: {invxPlusSqErr}, iterations {k++}\n");

	}
}
