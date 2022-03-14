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
		       	double dx = 0;
			double dy = 0;	
			int ix = binsearch(x, z);
			for(int i=0; i<ix; i++){
				dy = y[i+1] - y[i];
				dx = x[i+1] - x[i];
				cumsum += y[i]*dx + dy/dx * 0.5*dx*dx; 		
			} 
			dy = y[ix+1] - y[ix];
			dx = x[ix+1] - x[ix];
			cumsum += y[ix]*(z-x[ix]) + dy/dx * 0.5*(z-x[ix])*(z-x[ix]);
			return cumsum;
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
