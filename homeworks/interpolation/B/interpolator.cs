using static System.Math;

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
			c[0] = 0;
			
			for(int i=0; i<N-2; i++){
				c[i+1] = (p[i+1]-p[i] - c[i]*h[i])/h[i+1];
			}
			c[N-2] /= 2;
			
			for(int i=N-3; i>=0; i--){
				c[i] = (p[i+1]-p[i] - c[i+1]*h[i+1])/h[i];
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
			return 0;	
		}

		public double integ(double z){
			return 0;
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
