using static Integrator;
using static System.Math;
using static System.Console;
using System;

class main{
	public static void Main(){
		public double InvSqrtx(double x, int counter){
			counter++;
			return 1/(Sqrt(x));
		}
		Func<double,double> LogxSqrtxInv = (x => Log(x)/Sqrt(x));

		double logxSqrtxInvInt = vt_integrate(LogxSqrtxInv, 0, 1);
		double invSqrtxInt = vt_integrate(InvSqrtx, 0, 1);

		WriteLine($"2: {invSqrtxInt} \n-4: {logxSqrtxInvInt}");	
	}
}
