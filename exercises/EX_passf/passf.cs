using static System.Console;
using static System.Math;
using System;

public class passf{
	public static void make_table(Func<double,double> f, double a, double b, double dx){
		for(double i = a; i <= b; i += dx){
			WriteLine($"{i}, {f(i)}");	
		}
	}
}
