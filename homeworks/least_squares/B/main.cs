using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		double[] time = new double[] {1,2,3,4,6,9,10,13,15};
		double[] activity = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dy = new double[] {5,5,5,5,5,1,1,1,1};
		
		for(int i=0; i<time.Length; i++){	
			WriteLine($"{time[i]} {activity[i]} {dy[i]}");
		}
		WriteLine("\n");
		
		for(int i=0; i<activity.Length; i++){
			dy[i] = dy[i]/activity[i];
			activity[i] = Math.Log(activity[i]);
		}
		
		//Fit function has a constant and linear term		
		var fs = new Func<double,double>[] {z => 1.0, z => z};
                
		//Fitting
		var (c,S) = leastsq.lsfit(fs, time, activity, dy);
 
		double res=0;
		for(double t=0; t<=time.Max(); t+=1.0/8){
			res = 0;
			for(int j=0; j<fs.Length; j++){
				res += c[j]*fs[j](t);
				
			}
			//Exponentiating since fit is made in linear form
			res = Exp(res);
			WriteLine($"{t} {res}");
		}	
		WriteLine("\n");

		S.print();

		using(var outfile = new System.IO.StreamWriter("fitlog.txt")){
			outfile.WriteLine("\n");
			outfile.WriteLine($"Uncertainty on lambda: {Sqrt(S[1,1])} days");
		}
	}
}
