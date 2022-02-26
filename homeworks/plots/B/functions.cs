using static System.Math;

public static class functions{
	public static double erf(double x){
		if(x<0) return -erf(-x);
		double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
		double t=1/(1+0.3275911*x);
		double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
		return 1-sum*Exp(-x*x);
	}

	public static double gamma(double x, bool ln){
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
                if(ln)return lngamma;
		if(x<0)return PI/Sin(PI*x)/gamma(1-x, false);
		if(x<9)return gamma(x+1, false)/x;
		return Exp(lngamma);
	}
}
