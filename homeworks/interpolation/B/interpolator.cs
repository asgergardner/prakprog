static class interpolator{
	
	class linspline{
		private double[] x,y;
		linspline(x,y){
			x = x;
			y = y;
		}
        	public double eval(double z){
                	ix = binsearch(x, z);
                	double dy = y[i+1] - y[i];
			double dx = x[i+1] - x[i];
       		}
	}

	class qspline{
                private double[] x,y,b,c;
                qspline(x,y){
                        x = x;
                        y = y;
                }
                public double eval(double z){}
                public double derive(double z){}
                public double integ(double a, double b){}
        
	        }

	public static int binsearch(vector x, double z){
                /* locates the interval for z by bisection */
                int i=0, j=x.size-1;
                while(j-i>1){
                        int mid=(i+j)/2;
                        if(z>x[mid]) i=mid; else j=mid;
                }
                return i;
        }
