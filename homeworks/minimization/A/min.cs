using static System.Math;
using System;

public class min{
	private static double delta = Pow(2,-26);

	public static (vector, int) qnewton(Func<vector,double> f, vector x0, double acc){
		int steps=0;
		int maxsteps=50000;

		int dim=x0.size;
		vector x = x0.copy();
		matrix B = new matrix(dim,dim);
		B.set_identity();
		
		vector gx = gradient(f,x);

		//Backtracking linesearch
		while(steps<maxsteps){
			steps++;
			vector s = new vector(dim);
			vector xs;
			double fxs;
			double fx = f(x);
			double lambda = 1;
			vector Dx = -B*gx;
			while(true){
				steps++;
				s = lambda*Dx;
				xs = x+s;
				fxs = f(xs);
				if(fxs<fx){
					break;
				}
				if(lambda<delta){
					B.set_identity();
					break;
				}
				lambda /= 2;
			}
			vector gxs = gradient(f, xs);
			vector y = gxs-gx;
			vector u = s-B*y;
			double uTy = u%y;
			if(Abs(uTy)>1e-6){
				B.update(u,u,1/uTy);
			}
			x=xs;
			gx=gxs;
			fx=fxs;
			if(Abs(gx.norm())<acc){break;}
		}
		return (x,steps);
	}

	public static vector gradient(Func<vector,double> f, vector x){
	double dx;
	vector g = new vector(x.size);
	for(int i=0; i<x.size; i++){
		dx = Abs(x[i])*delta;
		if(Abs(x[i])<Sqrt(delta)){
			dx = delta;
		}
		vector xdx = x.copy();
		xdx[i] += dx;
		g[i] = (f(xdx)-f(x))/dx;

                }
	return g;
	}
}
