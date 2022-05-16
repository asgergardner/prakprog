using static System.Math;
using static System.Console;

class main{
	public static void Main(){
		complex minusOne = new complex(-1,0);
		WriteLine($"sqrt(-1) = {cmath.sqrt(minusOne)} should be 0+i");
		WriteLine($"sqrt(i) = {cmath.sqrt(cmath.I)} should be 0.707+0.707i");
		WriteLine($"e^i = {cmath.exp(cmath.I)} should be 0.54+0.84i");
		WriteLine($"e^(i*pi) = {cmath.exp(cmath.I*PI)} should be -1+0i");
		WriteLine($"i^i = {cmath.pow(cmath.I, cmath.I)} should be 0.208+0i");
		WriteLine($"ln(i) = {cmath.log(cmath.I)} should be 0+1.57i");
		WriteLine($"sin(i*pi) = {cmath.sin(cmath.I*PI)} should be 0+11.55i");
	}
}
