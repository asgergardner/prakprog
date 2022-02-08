using System;

class Week3{
	static void Main(){
		Calculator mainCalculator = new Calculator();
		Console.Write("Results:\n");
		Console.Write(mainCalculator.Sqrt2());
		Console.Write("\n", mainCalculator.Exp(Math.PI));
	}
}

class Calculator{
	public double Sqrt2(){
		return Math.Sqrt(2);
	}

	public double Exp(double arg){ 
		return Math.E(arg);
	}
}

