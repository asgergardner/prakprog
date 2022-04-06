using static Integrator;
using static System.Math;
using static System.Console;
using System;

class main{
	public static void Main(){
		Func<double,double> Sqrtx = (x => Sqrt(x));
		Func<double,double> InvSqrtx = (x => 1/(Sqrt(x)));
		Func<double,double> SqrtxSquare = (x => 4*Sqrt(1-x*x));
		Func<double,double> LogxSqrtxInv = (x => Log(x)/Sqrt(x));

		double sqrtxInt = integrate(Sqrtx, 0, 1);
		double invSqrtxInt = integrate(InvSqrtx, 0, 1);
		double sqrtxSquareInt = integrate(SqrtxSquare, 0, 1);
		double logxSqrtxInvInt = integrate(LogxSqrtxInv, 0, 1);

		WriteLine($"2/3: {sqrtxInt} \n2: {invSqrtxInt} \npi: {sqrtxSquareInt} \n-4: {logxSqrtxInvInt}");
		
		using(var outfile = new System.IO.StreamWriter("ploterf.txt")){
			for(double z=-3; z<=3; z+=1.0/16){
				outfile.WriteLine($"{z} {erf(z)}");
			}
		}		
	}

	public static double erf(double z){
                        Func<double, double> intfunc = t =>  Exp(-Pow(t,2));
                        return 2/Sqrt(PI)*integrate(intfunc, 0, z);
        }
}
