using System;
using static System.Math;
using static System.Console;
using static lagrange;

public class main{
	public static void Main(){
		int n = 5;
		matrix A = new matrix(n,n);
		var rand = new Random();
		for(int i=0; i<n; i++){
			int val = rand.Next(10);
			for(int j=0; j<n; j++){
				A[i,j] = val;
				A[j,i] = val;
			}
		}
		double lambdaInit = 1;
		(double lambdaRes, vector vRes) = EigenSearch(A, lambdaInit);
		
		WriteLine("\nStudent number: 201807822");
		WriteLine("Exam project: 22");
		WriteLine("\n **VARIATIONAL METHOD USING LAGRANGE MULTIPLIERS**\n");
		WriteLine("Initial randomly generated symmetric matrix A:");
		A.print();
		WriteLine($"\nInitial eigenvalue guess:\n {lambdaInit}");
		WriteLine($"\nFound eigenvalue:\n {lambdaRes}");
		WriteLine("\nCorresponding (normalized) eigenvector:");
		vRes.print();

		//Hydrogen ground state search
		Func<double,double> analyticalS = x => 2*Exp(-x);
		(double gse, double stepsize, vector gsv, vector rs) = HydrogenGS();
		WriteLine("\nHYDROGEN GROUND STATE:");
		WriteLine($"Found ground state energy: {gse}");
		WriteLine("Plot of corresponding eigenvector in HGS.png");
		using(var outfile = new System.IO.StreamWriter("hydrogenGS.txt")){
			for(int k=0; k<gsv.size; k++){
				outfile.WriteLine($"{rs[k]} {gsv[k]/Sqrt(stepsize)} {rs[k]*analyticalS(rs[k])}");
			}
		}
	}

	public static (double, double, vector, vector) HydrogenGS(){
		double rmax=20,dr=0.1;
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);
		for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
  			matrix.set(H,i,i,-2);
 		 	matrix.set(H,i,i+1,1);
  			matrix.set(H,i+1,i,1);
  		}
		matrix.set(H,npoints-1,npoints-1,-2);
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

		double gsGuess = -0.5;
		(double gsEnergy, vector gsVector) = EigenSearch(H, gsGuess);
		return (gsEnergy, dr, gsVector, r);
	}
}
