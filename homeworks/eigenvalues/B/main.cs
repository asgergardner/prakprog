using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		CompareSolutions();
		CheckRConvergence();
		CheckNConvergence();
	}

	public static void CheckRConvergence(){
		int np = 100; 
		int rmax = 10;
		using(var outfile = new System.IO.StreamWriter("r_convergence.txt")){
			for(double r=1; r<rmax; r+=0.2){ 
				(matrix H, vector rs, double dr) = GenerateH(np, r);
				(vector e, matrix V) = evd.JacobiDiag(H);
                        	outfile.WriteLine($"{r} {e[0]} {-0.5}");
			}
		}
	}

	public static void CheckNConvergence(){
		int rmax = 5;
		int nmax = 100;
		using(var outfile = new System.IO.StreamWriter("n_convergence.txt")){
			for(int np=10; np<nmax; np+=5){
				(matrix H, vector r, double dr) = GenerateH(np, rmax);
                        	(vector e, matrix V) = evd.JacobiDiag(H);
				outfile.WriteLine($"{np} {e[0]} {-0.5}");
                        }
		}
	}

	public static void CompareSolutions(){
		(matrix H, vector r, double dr) = GenerateH(250, 50);
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

	public static (matrix, vector, double) GenerateH(int npoints, double rmax){
                double dr=rmax/(npoints+1);
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
