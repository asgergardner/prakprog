using static System.Random;
using static System.Math;
using System;

public static class mc{
	public static (double, double) plainmc(Func<vector,double> intf, vector a, vector b, int N){
		int n = a.size;
		double V = 1;
		for(int i=0; i<n; i++){
			V*=b[i]-a[i];
		}
		vector x = new vector(n);
		double sum = 0;
		double sqsum = 0;
		var rand = new Random();
		for(int i=0; i<N; i++){
			for(int j=0; j<n; j++){
				x[j]=a[j]+rand.NextDouble()*(b[j]-a[j]);
			}
			double fx = intf(x);
			sum += fx;
			sqsum += fx*fx;
		}
		double mean = sum/N;
		double sigma = Sqrt(sqsum/N - mean*mean);
		return(mean*V, sigma*V/Sqrt(N));	
	}
}
