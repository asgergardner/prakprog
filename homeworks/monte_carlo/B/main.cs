using static mc;
using static System.Math;
using static System.Console;
using System;

public class main{
	public static void Main(){
		int NInit = 100000;
		int NEnd = 1000000;
		int NInterval = 100000;
		vector a0 = new double[2] {0,0};
		vector b0 = new double[2] {1,1};
		Func<vector,double> xy = vars => vars[0]*vars[1];
		WriteLine("Integral of x*y from x=y=0 to x=y=1");
		for(int N=NInit;N<=NEnd;N+=NInterval){
			var res1 = quasimc(xy,a0,b0,N);
			var res2 = plainmc(xy,a0,b0,N);
			double table = 0.25;
			WriteLine($"actual: {table} pseudo: {res2.Item1} quasi: {res1.Item1} error difference: {((res2.Item1-table) - (res1.Item1-table))} points: {N}");
		}
		WriteLine("\n");

		vector a2 = new double[3] {0,0,0};
		vector b2 = new double[3] {PI,PI,PI};
		Func<vector,double> testf = vars => 1/((1 - Cos(vars[0])*Cos(vars[1])*Cos(vars[2]))*(PI*PI*PI));
		WriteLine("Integral of (1-cos(x)*cos(y)*cos(z))^-1 from 0 to pi");
		for(int N=NInit;N<=NEnd;N+=NInterval){
                        var res3 = quasimc(testf,a2,b2,N);
			var res4 = plainmc(testf,a2,b2,N);
			double table = 1.3932039296856768591842462603255;
			WriteLine($"actual: {table} pseudo: {res4.Item1} quasi: {res3.Item1} error difference: {((res4.Item1-table) - (res3.Item1-table))} points: {N}");
                }
	}
}
