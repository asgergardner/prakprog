using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		CheckRConvergence();
		CheckNConvergence();
		CompareSolutions();
	}

	public static void CheckRConvergence(){ 
		int rmax = 30;
		double dr = 0.2; //Value taken from GenerateH method; could be written prettier I suppose
		double[] table_energies = new double[] {-0.5, -0.125, -0.055};
		using(var outfile = new System.IO.StreamWriter("r_convergence.txt")){
			for(int energy=0; energy<=2; energy++){
				for(double r=1; r<rmax; r+=0.5){
					int np = (int)(r/(dr-0.1));	
					(matrix H, vector rs, double dr_H) = GenerateH(np);
					(vector e, matrix V) = evd.JacobiDiag(H);
                        		outfile.WriteLine($"{r} {e[energy]} {table_energies[energy]}");
				}
				outfile.WriteLine("\n");
			}
		}
	}

	public static void CheckNConvergence(){
		int rmax = 10;
		int nmax = 200;
		double[] table_energies = new double[] {-0.5, -0.125, -0.055};
		using(var outfile = new System.IO.StreamWriter("n_convergence.txt")){
			for(int energy=0; energy<=2; energy++){
				for(int np=10; np<nmax; np+=5){
					(matrix H, vector r, double dr) = GenerateH(np);
                        		(vector e, matrix V) = evd.JacobiDiag(H);
					outfile.WriteLine($"{np} {e[energy]} {table_energies[energy]}");
                        	}
				outfile.WriteLine("\n");
			}
		}
	}

	public static void CompareSolutions(){
		(matrix H, vector r, double dr) = GenerateH(250);
                (vector e, matrix V) = evd.JacobiDiag(H);

                var analyticalS = new Func<double,double>[] {x => 2*Exp(-x), x => -1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2), x => 2.0/(3*Sqrt(3))*(1-2.0/3*x+2.0/27*x*x)*Exp(-x/3)};

                int eMax = 2;
                for(int eLevel=0; eLevel<=eMax; eLevel++){
                        for(int i=0; i<V.size1; i++){
                                WriteLine($"{r[i]} {V[eLevel][i]/Sqrt(dr)} {r[i]*analyticalS[eLevel](r[i])}");
                        }
                WriteLine("\n");
                }

	}

	public static (matrix, vector, double) GenerateH(int npoints){
                double dr=0.2;
                vector r = new vector(npoints);
                for(int i=0;i<npoints;i++){
                        r[i]=dr*(i+1);
                }
                matrix H = new matrix(npoints,npoints);
                for(int i=0;i<npoints-1;i++){
                        matrix.set(H,i,i,-2);
                        matrix.set(H,i,i+1,1);
                        matrix.set(H,i+1,i,1);
                }
                matrix.set(H,npoints-1,npoints-1,-2);
                H*=-0.5/dr/dr;
                for(int i=0;i<npoints;i++){
                        H[i,i]+=-1/r[i];
                }
		return (H, r, dr);
	}
}
