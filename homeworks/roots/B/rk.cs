using System; 
using static System.Math;
using System.Collections.Generic;

public class rk45{
	public static (vector, vector) step(Func<double,vector,vector> f, double x, vector y, double h){
		//c values:
		double c1 = 0;
		double c2 = 1.0/4;
		double c3 = 3.0/8;
		double c4 = 12.0/13;
		double c5 = 1.0;
		double c6 = 1.0/2;

		//b values:
		double b1 = 16.0/135;
		double b2 = 0;
		double b3 = 6656.0/12825;
		double b4 = 28561.0/56430;
		double b5 = -9.0/50;
		double b6 = 2.0/55;

		//b* values:
		double b1s = 25.0/216;
		double b2s = 0;
		double b3s = 1408.0/2565;
		double b4s = 2197.0/4104;
		double b5s = -1.0/5;
		double b6s = 0;

		//a values:
		double a11 = 0;	
		double a21 = 1.0/4;
		double a31 = 3.0/32;
		double a41 = 1932.0/2197;
		double a51 = 439.0/216;
		double a61 = -8.0/27;

		double a32 = 9.0/32;
		double a42 = -7200.0/2197;
		double a52 = -8.0;
		double a62 = 2.0;

		double a43 = 7296.0/2197;
		double a53 = 3680.0/513;
		double a63 = -3544.0/2565;

		double a54 = -845.0/4104;
		double a64 = 1859.0/4104;

		double a65 = -11.0/40;

		//Calculating K-values 
		vector K1 = h*f(x,y);
		vector K2 = h*f(x+c2*h, y+a21*K1);
		vector K3 = h*f(x+c3*h, y+a31*K1+a32*K2);
		vector K4 = h*f(x+c4*h, y+a41*K1+a42*K2+a43*K3);
		vector K5 = h*f(x+c5*h, y+a51*K1+a52*K2+a53*K3+a54*K4);
		vector K6 = h*f(x+c6*h, y+a61*K1+a62*K2+a63*K3+a64*K4+a65*K5);

		vector ys = y+b1s*K1+b2s*K2+b3s*K3+b4s*K4+b5s*K5+b6s*K6;
		vector yh = y+b1*K1+b2*K2+b3*K3+b4*K4+b5*K5+b6*K6;
		vector er = yh-ys;

		return (yh, er);
	}

	public static vector driver(Func<double,vector,vector> f, double a, double b, vector ya, List<double> xlist = null, List<vector> ylist = null, double h=0.01, double acc=0.01, double eps=0.01){
		if(a>b){throw new Exception("start point a must be lower than end point b");}

		double x = a;
		vector y = ya;
		int i=0; int maxIter = 50000; 
		while(i<=maxIter){
			if(x>=b){return y;}
			if(x+h>b){h = b-x;}
			var (yh, erv) = step(f, x, y, h);
			vector tol = new vector(yh.size);
			bool ok = true;
			for(int j=0; j<yh.size; j++){
				tol[j] = Max(acc, Abs(yh[j])*eps)*Sqrt(h/(b-a));
				ok = (ok && erv[j]<tol[j]);
			}
			
			if(ok){ 
				x+=h; 
				y=yh;
				if(xlist != null || ylist != null){
                                        xlist.Add(x);
                                        ylist.Add(y);
                                }
			}
			
			double factor = tol[0]/Abs(erv[0]);
                        for(int n=1;n<tol.size;n++){ 
				factor=Min(factor,tol[n]/Abs(erv[n]));
                                double power = 0.25;
                                double safety = 0.95;
                                h *= Min( Pow(factor,power)*safety ,2);
			}
			i++;
			/*
			double err = erv.norm();
			if(err<=tol){x+=h; y=yh;}
				double power = 0.25;
				double safety = 0.95;
				h*=Min(Pow(tol/err, power)*safety, 2);
				
				if(xlist != null || ylist != null){
					xlist.Add(x);
					ylist.Add(y);
				}
				i++;
			*/
		}
		throw new Exception("Iteration exceeded max steps: stopping");
	}
}
