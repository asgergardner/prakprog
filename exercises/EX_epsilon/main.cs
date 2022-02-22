using static System.Console;

class main{
	public static void Main(){
		epsilon.MaxInt();
		epsilon.MinInt();
		epsilon.MachineEps();
		epsilon.Summing();
		WriteLine($"1 + 5*epsilon is approximately equal to 1: {epsilon.approx(1, 1+5*1e-9)}");
		WriteLine($"1 + epsilon/2 is approximately equal to 1: {epsilon.approx(1, 1+1e-9/2)}");		
	}
}
