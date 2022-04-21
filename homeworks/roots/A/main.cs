using static System.Console;
using static roots;
using System;

class main{
	public static void Main(){
		Func<vector,vector> rosenbrock = delegate(vector args){
			vector f = new vector(2); 
			f[0] = 2*(200*args[0]*args[0]*args[0] - 200*args[0]*args[1] + args[0] -1);
			f[1] = 200*(args[1]-args[0]*args[0]);
			return f;
		};

		vector x0 = new double[] {0.1,0.1};
		vector res = nroots(rosenbrock, x0, 1e-16);

		WriteLine("\nRosenbrock function extremum (x,y):");
	       	WriteLine($"({res[0]}, {res[1]})");
	}
}
