using static System.Math;
using static System.Console;
using System;

class main{
	public static void Main(){
		Func<double,double> intfunc = delegate(double x){return Log(x)/Sqrt(x);};
		double ans = integrate.quad(intfunc, 0, 1);
		WriteLine($"Integration of Log(x)/Sqrt(x) from 0 to 1: {ans}");
		WriteLine("\n"); // Adding additional newline to create index for pyxplot
		for(double i=-2;i<=2;i+=1.0/8){
			WriteLine($"{i} {errfunc(i)}");
		}
	}

	public static double errfunc(double z){
		Func<double, double> intfunc = t =>  Exp(-Pow(t,2));
		return 2/Sqrt(PI)*integrate.quad(intfunc, 0, z);
	}
}
