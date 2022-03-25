using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		int npoints=250;
		double rmax=50;
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

		vector e;
		matrix V;
		(e,V) = evd.JacobiDiag(H);
	
		var analyticalS = new Func<double,double>[] {x => 2*Exp(-x), x => 1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2), x => 2.0/(3*Sqrt(3))*(1-2.0/3*x+2.0/27*x*x)*Exp(-x/3)};	

		int eMax = 2;
		for(int eLevel=0; eLevel<=eMax; eLevel++){
			for(int i=0; i<V.size1; i++){
				WriteLine($"{r[i]} {V[eLevel][i]/Sqrt(dr)} {r[i]*analyticalS[eLevel](r[i])}");
			}
		WriteLine("\n");
		}	

	}
}
