using System;
using static System.Console;
using static min;

class main{
	public static void Main(){

		//Rosenbrock function
		Func<vector,double> rosenbrock = delegate(vector args){
			return (1-args[0])*(1-args[0]) +100*(args[1]-args[0]*args[0])*(args[1]-args[0]*args[0]);
		};			
		vector x0 = new double[] {0.1,0.1};
		double acc = 1e-5;
		var resRos = qnewton(rosenbrock, x0, acc); 	
		WriteLine($"\nRosenbrock minimum at ({resRos.Item1[0]},{resRos.Item1[1]}) found after {resRos.Item2} steps with accuracy {acc}");
		
		//Himmelblau's function
		Func<vector,double> himmelblau = delegate(vector args){
			return (args[0]*args[0]+args[1]-11)*(args[0]*args[0]+args[1]-11) + (args[0]+args[1]*args[1]-7)*(args[0]+args[1]*args[1]-7);
		};
		x0 = new double[] {2,1};
		acc = 1e-5;
		var resHim = qnewton(himmelblau, x0, acc);
		WriteLine($"\nHimmelblau minimum at ({resHim.Item1[0]},{resHim.Item1[1]}) found after {resHim.Item2} steps with accuracy {acc}");
	}
}
