using static System.Math;
using System.Diagnostics;

public static class interpolator{
	
	public class linspline{
		private double[] x;
		private double[] y;
		
		public linspline(double[] x, double[] y){
			this.x = x;
			this.y = y;
		}

        	public double eval(double z){
                	int ix = binsearch(x, z);
                	double dy = y[ix+1] - y[ix];
			double dx = x[ix+1] - x[ix];
			return y[ix] + dy/dx * (z-x[ix]);
       		}

		public double integ(double z){
			double cumsum = 0; 
			int ix = binsearch(x, z);
			for(int i=0; i<=ix; i++){
				double dy = y[i+1] - y[i];
				double dx = x[i+1] - x[i];
				cumsum += y[i] * (x[i+1]-x[i]) + dy/dx * Pow(x[i+1]-x[i],2)/2; 		
			}
			return cumsum;
		}
	}

	public class qspline{
		private double[] x;
		private double[] y;
		public double[] b;
		public double[] c;

		public qspline(double[] x, double[] y){
			this.x = x;
			this.y = y;
			int N = x.Length;
			this.b = new double[N-1] ;
			this.c = new double[N-1];
			
			// recursively determining constants
			double[] p = new double[N-1];
			double[] h = new double[N-1];
				
			for(int i=0; i<N-1; i++){
				h[i] = x[i+1] -x[i];
				p[i] = (y[i+1] -y[i])/h[i];
			}
			
			// recursion up
			double[] c_up = new double[N-1];
			c_up[0] = 0;
			for(int i=0; i<N-2; i++){
				c_up[i+1] = (p[i+1]-p[i] - c_up[i]*h[i])/h[i+1];
			}
			
			// recursion down
			double[] c_down = new double[N-1];
			c_down[N-2] = 0;
			for(int i=N-3; i>=0; i--){
				c_down[i] = (p[i+1]-p[i] - c_down[i+1]*h[i+1])/h[i];
			}
			
			// averaging
			for(int i=0; i<N-1; i++){
				c[i] = (c_up[i] + c_down[i])/2;
			}

					
			for(int i=0; i<N-1; i++){
				b[i] = p[i] - c[i]*h[i];
			}
			
		}

		public double eval(double z){
			int ix = binsearch(x, z);
			double h = z-x[ix];
			return y[ix] + b[ix]*h + c[ix]*Pow(h,2);
		}

		public double deriv(double z){
			int ix = binsearch(x, z);
			double h = z-x[ix];
			return b[ix] + 2*c[ix]*h;	
		}

		public double integ(double z){
			int ix = binsearch(x, z);
			double dx,cumsum = 0;
			for(int i=0; i<ix; i++){
				dx = x[i+1] -x[i];
				cumsum += y[i]*dx + 1.0/2*b[i]*Pow(dx,2) + 1.0/3*c[i]*Pow(dx,3);
			}
			dx = z - x[ix];
			cumsum += y[ix]*dx + 1.0/2*b[ix]*Pow(dx,2) + 1.0/3*c[ix]*Pow(dx,3);
			return cumsum;
		}
	
	}

	public class cspline{
		private double[] x;
                private double[] y;
                private double[] b;
                private double[] c;
                private double[] d;	

	public cspline(double[] xs,double[] ys){
		int n=xs.Length; Trace.Assert(ys.Length>=n);
		x=new double[n];
                y=new double[n];
                b=new double[n];
                c=new double[n-1];
                d=new double[n-1];
		for(int i=0;i<n;i++){x[i]=xs[i];y[i]=ys[i];}
		var D = new double[n];
		var Q = new double[n-1];
		var B = new double[n];
		var h = new double[n-1];
		var p = new double[n-1];
		for(int i=0;i<n-1;i++) { h[i]=x[i+1]-x[i]; Trace.Assert(h[i]>0);}
		for(int i=0;i<n-1;i++) { p[i]=(y[i+1]-y[i])/h[i]; }

		D[0]=2; Q[0]=1; B[0]=3*p[0]; D[n-1]=2; B[n-1]=3*p[n-2];
		for(int i=0;i<n-2;i++){
   			D[i+1]=2*h[i]/h[i+1]+2;
   			Q[i+1]=h[i]/h[i+1];
   			B[i+1]=3*(p[i]+p[i+1]*h[i]/h[i+1]);
		}

		for(int i=1;i<n;i++){
			D[i]-=Q[i-1]/D[i-1];
			B[i]-=B[i-1]/D[i-1];
		}

		b[n-1]=B[n-1]/D[n-1];
		
		for(int i=n-2;i>=0;i--){
		b[i]=(B[i]-Q[i]*b[i+1])/D[i];
		}

		for(int i=0;i<n-1;i++){
   		c[i]=(-2*b[i]-b[i+1]+3*p[i])/h[i];
   		d[i]=(b[i]+b[i+1]-2*p[i])/h[i]/h[i];
		}
	}//construcntor

	public double eval(double z){/* evaluation of the spline at point z */
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int i=binsearch(x,z);
		double dx=z-x[i];/* calculate the inerpolating spline : */
		return y[i]+dx*(b[i]+dx*(c[i]+dx*d[i]));
	}

	public double deriv(double z){/* derivative of the spline at point z */
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int i=binsearch(x,z);
		double dx=z-x[i];
		return b[i]+dx*(2*c[i]+dx*3*d[i]);
	}

	public double integ(double z){/* derivative of the spline at point z */
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int iz=binsearch(x,z);
		double sum=0,dx;
		for(int i=0;i<iz;i++){
			dx=x[i+1]-x[i];
			sum+=dx*(y[i]+dx*(b[i]/2+dx*(c[i]/3+dx*d[i]/4)));
		}
		dx=z-x[iz];
		sum+=dx*(y[iz]+dx*(b[iz]/2+dx*(c[iz]/3+dx*d[iz]/4)));
		return sum;
	}

	}	

	public static int binsearch(double[] x, double z){
                /* locates the interval for z by bisection */
                int i=0, j=x.Length-1;
                while(j-i>1){
                        int mid=(i+j)/2;
                        if(z>x[mid]) i=mid; else j=mid;
                }
                return i;
        }
}
