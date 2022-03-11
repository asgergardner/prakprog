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
		       	double dx, dy;	
			int ix = binsearch(x, z);
			for(int i=0; i<ix; i++){
				dy = y[i+1] - y[i];
				dx = x[i+1] - x[i];
				cumsum += y[i]*dx + dy/dx * 0.5*Pow(dx,2); 		
			} 
			dy = y[ix+1] -y[ix];
			dx = z -x[ix];
			cumsum += y[ix]*dx + dy/dx * 0.5*Pow(dx,2);
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
