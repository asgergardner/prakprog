using System;
using static System.Math;
using static System.Console;

class Week3{
	static void Main(){
		Calculator mainCalculator = new Calculator();
		double sqrt2 = mainCalculator.Sqrt2();
		double exppi = mainCalculator.Expo(PI);
		double piexp = mainCalculator.Power(PI, E);
		WriteLine($"Results:\n sqrt(2) = {sqrt2} \n exp(pi) = {exppi} \n pi^exp = {piexp}");
		WriteLine($"Inverse operations:\n sqrt(2)*sqrt(2) = {sqrt2*sqrt2} \n log(exp(pi)) = {Log(exppi)} \n (pi^e)^1/e = {Pow(piexp,1/E)}");
			
	}
}

class Calculator{
	public double Sqrt2(){
		return Sqrt(2);
	}

	public double Expo(double arg){ 
		return Exp(arg);
	}

	public double Power(double root, double pow){
		return Pow(root, pow);
	}
}

