using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		
		int N = 20;
		double[] xtable = new double[N];
                double[] ytable = new double[N];
		for(int i=0; i<N; i++){
			xtable[i] = i;
			ytable[i] = Cos(i);	
		} 

		interpolator.linspline lspline = new interpolator.linspline(xtable, ytable);
		
		for(int i=0;i<xtable.Length;i++){
			double interp = lspline.eval(xtable[i]);
			double int_interp = lspline.integ(xtable[i]);
			WriteLine($"{xtable[i]} {ytable[i]} {interp} {int_interp}");
		}
	}
}
