using static Integrator;
using static System.Math;
using static System.Console;
using System;

class main{
	public static void Main(){
		int i=0;
		int j=0;
		Func<double,double> LogxSqrtxInv = x => {i++; return Log(x)/Sqrt(x);};
		Func<double,double> InvSqrtx = x => {j++; return 1/Sqrt(x);};
		double logxSqrtxInvInt = vt_integrate(LogxSqrtxInv, 0, 1);
		double invSqrtxInt = vt_integrate(InvSqrtx, 0, 1);

		int k=0;
		int n=0;
		Func<double,double> initLogxSqrtxInv = x => {n++; return Log(x)/Sqrt(x);};
                Func<double,double> initInvSqrtx = x => {k++; return 1/Sqrt(x);};
		double initLog = integrate(initLogxSqrtxInv, 0, 1);
		double initSqrtx = integrate(initInvSqrtx, 0, 1);

		WriteLine($"\n 1/sqrt(x) iterations: \n initial: {k} \n transformed: {i} \n \n log(x)/sqrt(x) iterations: \n initial: {n} \n transformed: {j} \n");	
	}
	/*
	public double InvSqrtx(double x, int counter){
                        counter++;
                        return 1/(Sqrt(x));
        }*/
}
