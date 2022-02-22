using static System.Console;
using static System.Math;

public static class epsilon{
	public static void MaxInt(){
		int i = 1;
		while(i+1>i){
			i++;
		}
		WriteLine($"max int = {i}");
		WriteLine($"int.MaxValue = {int.MaxValue}");
	}

	public static void MinInt(){
		int i = 1;
                while(i-1<i){
                        i--;
                }
                WriteLine($"min int = {i}");
                WriteLine($"int.MinValue = {int.MinValue}");
	}

	public static void MachineEps(){
		double d = (double)1;
		float f = (float)1;
		while((double)1+d != (double)1){
			d/=(double)2;
		}
		d*=(double)2;
		while((float)((float)1 + f) != (float)1){
			f/=(float)2;
		}
		f*=(float)2;
		WriteLine($"Machine epsilon double : {d}. Should approximate {Pow(2,-52)}");
		WriteLine($"Machine epsilon float : {f}. Should approximate {Pow(2,-23)}");
	}

	public static void Summing(){
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA = 0;
		double sumB = 0;

		int n = (int)1e6;
		sumA+=1;
		for(int i=0;i<n;i++){
			sumA+=tiny;
			sumB+=tiny;
		}
		sumB+=1;
		WriteLine($"Sum A - 1 = {sumA-1} should be {n*tiny}");
		WriteLine($"Sum A - 1 = {sumB-1} should be {n*tiny}");
	}

	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		return (Abs(a-b) < tau) | ((Abs(a-b)/(Abs(a) + Abs(b))) < epsilon);
	}
}
