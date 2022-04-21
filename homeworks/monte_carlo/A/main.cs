using static mc;
using static System.Math;
using static System.Console;
using System;

public class main{
	public static void Main(){
		int NInit = 50000;
		int NEnd = 1000000;
		int NInterval = 50000;
		vector a0 = new double[2] {0,0};
		vector b0 = new double[2] {1,1};
		Func<vector,double> xy = vars => vars[0]*vars[1];
		WriteLine("Integral of x*y from x=y=0 to x=y=1");
		for(int N=NInit;N<=NEnd;N+=NInterval){
			var res = plainmc(xy,a0,b0,N);
			WriteLine($"res: {res.Item1} error: {res.Item2} points: {N}");
		}
		WriteLine("\n");

		vector a1 = new double[2] {-1,-1};
		vector b1 = new double[2] {1,1};
		Func<vector,double> circle = delegate(vector vars){
			double sqsq = Sqrt((vars[0]*vars[0]+vars[1]*vars[1])/PI);
			if(sqsq>1){
				return 0;
			}else{
				return sqsq;
			}
		};
		WriteLine("Integral of r = sqrt(x^2+y^2) from x=y=-1 to x=y=1");
		for(int N=NInit;N<=NEnd;N+=NInterval){
			var res1 = plainmc(circle,a1,b1,N);
			WriteLine($"res: {res1.Item1} error: {res1.Item2} points: {N}");
		}
		WriteLine("\n");

		vector a2 = new double[3] {0,0,0};
		vector b2 = new double[3] {PI,PI,PI};
		Func<vector,double> testf = vars => 1/((1 - Cos(vars[0])*Cos(vars[1])*Cos(vars[2]))*(PI*PI*PI));
		WriteLine("Integral of (1-cos(x)*cos(y)*cos(z))^-1 from 0 to pi");
		for(int N=NInit;N<=NEnd;N+=NInterval){
                        var res2 = plainmc(testf,a2,b2,N);
                        WriteLine($"res: {res2.Item1} error: {res2.Item2} points: {N}");
                }
	}
}
