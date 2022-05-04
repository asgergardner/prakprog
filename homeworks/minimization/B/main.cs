using System;
using static System.Console;
using static min;
using System.IO;
using static System.Double;

class main{
	public static void Main(){
		string[] lines = File.ReadAllLines("data.txt");
                int k = 0;
                int n = lines.Length;
                vector Es = new double[n];
                vector sigmas = new double[n];
                vector dsigmas = new double[n];

                foreach (string line in lines){
                        string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Es[k] = Double.Parse(values[0]);
                        sigmas[k] = Double.Parse(values[1]);
                        dsigmas[k] = Double.Parse(values[2]);
                        k++;

                }

		Func<vector,double,double> BW = delegate(vector param, double E){
			return param[2]/((E-param[0])*(E-param[0]) + param[1]*param[1]/4);

		};

		Func<vector,double> deviation = delegate(vector param){
			double res=0;
			for(int i=0;i<Es.size;i++){
				res+=((BW(param, Es[i])-sigmas[i])/dsigmas[i])*((BW(param, Es[i])-sigmas[i])/dsigmas[i]);
			}
			return res;
		};
		
		vector init = new double[] {120,3,6};
		double acc = 1e-3;
		var result = qnewton(deviation,init,acc);
		WriteLine("\n	**Fitting Higgs boson data**	\n");
		WriteLine($"Initial guess m={init[0]}, Gamma={init[1]}, A={init[2]}, accuracy is {acc}");
		WriteLine($"Output fit parameters: m={result.Item1[0]}, Gamma={result.Item1[1]}, A={result.Item1[2]}, solved in {result.Item2} steps");	
	}
}
