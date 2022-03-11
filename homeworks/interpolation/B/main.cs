using static System.Console;
using static System.Math;
using static interpolator;
using System.Collections.Generic;
using System.Linq;

class main{
	public static void Main(){
		
		
		int N = 20;
		int div = 8;
		double step = 1.0/div;
		double[] cos_xtable = new double[N*div];
                double[] cos_ytable = new double[N*div];
		int ix = 0;
		for(double i=0; i<N-step; i+=step){
			cos_xtable[ix] = i;
			cos_ytable[ix] = Cos(i);
			ix++;	
		} 
		
		/*
		interpolator.linspline lspline = new interpolator.linspline(xtable, ytable);
		
		for(int i=0;i<xtable.Length;i++){
			double interp = lspline.eval(cos_xtable[i]);
			double int_interp = lspline.integ(cos_xtable[i]);
			WriteLine($"{cos_xtable[i]} {cos_ytable[i]} {interp} {int_interp}");
		}
		*/
		
		

		// Checking qspline for datasets given in homework
		double[] xtable = new double[] {-5,-4,-3,-2,-1,0,1,2,3,4,5};
	       	double[] ytable1 = new double[] {1,1,1,1,1,1,1,1,1,1,1};
		double[] ytable2 = new double[] {-5,-4,-3,-2,-1,0,1,2,3,4,5};
		double[] ytable3 = new double[] {25,16,9,4,1,0,1,4,9,16,25};	
		double[] ytable4 = new double[] {0,0,0,0,0,0,1,1,1,1,1};

		var ys = new List<double[]> {ytable1, ytable2, ytable3, ytable4};
		
		foreach(var y in ys){
			qspline qdspline = new qspline(xtable, y);
			
			for(int i=0; i<y.Length; i++){
				WriteLine($"{xtable[i]} {y[i]}");
			}
			
			WriteLine("\n");

			for(double x=xtable.Min(); x<xtable.Max(); x+=step){
				double interp = qdspline.eval(x);
				double deriv = qdspline.deriv(x);
				double integ = qdspline.integ(x);
				WriteLine($"{x} {interp} {deriv} {integ}");
			}

			WriteLine("\n");
		}
		
		
	}
}
