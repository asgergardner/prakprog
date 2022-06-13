using static System.Math;
using static System.Console;
using static lineq;
using System;

public class roots{
	public static vector nroots(Func<vector,vector> f, vector x0, matrix A, double eps=1e-6){
		vector x = x0.copy();
		int n = x.size;
		vector fx = new vector(x0);
		
		while(true){
			fx = f(x);
			matrix J = LagrangeJacobi(A,x);
			matrix R = new matrix(n,n);
			matrix Q = J.copy();
			QRGSdecomp(Q,R);
			vector dx = QRGSsolve(Q,R,-fx);
			
			double lambda = 2.0;
			vector y = new vector(n);
			vector fy = new vector(n);
			while(true){
				lambda /= 2;
				y = x+lambda*dx;
				fy = f(y);
				if(fy.norm()<(1-lambda/2.0)*fx.norm() || lambda<1.0/64){break;}

			}
			x = y;
			fx = fy;
			if(fx.norm()<eps){break;}
		}
		return x;
	}
	public static matrix LagrangeJacobi(matrix A, vector x){
		int n = A.size1;
		matrix J = new matrix(n+1,n+1);
		vector v = new vector(n);
		for(int k=0; k<n; k++){
			v[k] = x[k];
		}
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				if(i==j){
					J[i,j] = A[i,j] - x[n];
				}else{
					J[i,j] = A[i,j];
				}	
			}
		}
		for(int l=0; l<n; l++){
			J[l,n] = -v[l];
			J[n,l] = 2*v[l];
		}
		J[n,n] = 0;
		return J;
	}
}
