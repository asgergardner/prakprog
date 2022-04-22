using static System.Math;
using static System.Console;
using static lineq;
using System;

public class roots{
	public static vector nroots(Func<vector,vector> f, vector x0, double eps=1e-2){
		vector x = x0.copy();
		int n = x.size;
		matrix J = new matrix(n,n);
		double delta = 1.0;
		vector fx = new vector(x0);

		while(true){	
			fx = f(x);
			for(int i=0;i<n;i++){
				delta = Abs(x[i])*Pow(2,-26);
				for(int k=0;k<n;k++){
					vector xdx = x.copy();
					xdx[k]+=delta;
					J[i,k] = (f(xdx)[i]-fx[i])/delta;
				}
			}
			matrix R = new matrix(n,n);
			matrix Q = J.copy();
			QRGSdecomp(Q,R);
			vector dx = QRGSsolve(Q,R,-fx);
			
			double lambda = 2.0;
			vector fdx = f(x+lambda*dx);
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
			if(dx.norm()<delta || fx.norm()<eps){break;}
		}
		return x;
	}
}
