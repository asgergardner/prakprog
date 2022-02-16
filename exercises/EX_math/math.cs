using System;

class Week3{
	static void Main(){
		Calculator mainCalculator = new Calculator();
		double sqrt2 = mainCalculator.Sqrt2();
		double exppi = mainCalculator.Exp(Math.PI);
		double piexp = mainCalculator.Power(Math.PI, Math.E);
		Console.WriteLine($"Results:\n sqrt(2) = {sqrt2} \n exp(pi) = {exppi} \n pi^exp = {piexp}");
	}
}

class Calculator{
	public double Sqrt2(){
		return Math.Sqrt(2);
	}

	public double Exp(double arg){ 
		return Math.Exp(arg);
	}

	public double Power(double root, double pow){
		return Math.Pow(root, pow);
	}
}

