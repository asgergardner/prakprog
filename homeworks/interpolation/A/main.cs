using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		
		int N = 5;
		int div = 3;
		double step = 1.0/div;
		double[] xtable = new double[N*div];
                double[] ytable = new double[N*div];
		int ix = 0;
		for(double i=0; i<N-step; i+=step){
			xtable[ix] = i;
			ytable[ix] = Cos(i);
			ix++;	
		} 

		interpolator.linspline lspline = new interpolator.linspline(xtable, ytable);
		
		for(int i=0;i<xtable.Length;i++){
			WriteLine($"{xtable[i]} {ytable[i]}");
		}

		WriteLine("\n");
		
		int N_plot = N;
		int div_plot = 64;	
		double step_plot = 1.0/div_plot;
		int idx = 0; 
		for(double x=0; x<N_plot; x+=step_plot){
			double interp = lspline.eval(x);
                        double integ = lspline.integ(x);
			WriteLine($"{x} {interp} {integ}");
			idx++;
		}
	}
}
