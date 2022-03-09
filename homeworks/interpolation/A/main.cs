using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		
		int N = 20;
		int div = 8;
		double[] xtable = new double[N*div];
                double[] ytable = new double[N*div];
		int ix_count = 0;
		for(double i=0; i<N; i=1.0/div){
			xtable[ix_count] = i;
			ytable[ix_count] = Cos(i);
			ix_count++;	
		} 

		interpolator.linspline lspline = new interpolator.linspline(xtable, ytable);
		
		for(int i=0;i<xtable.Length;i++){
			double interp = lspline.eval(xtable[i]);
			double int_interp = lspline.integ(xtable[i]);
			WriteLine($"{xtable[i]} {ytable[i]} {interp} {int_interp}");
		}
	}
}
