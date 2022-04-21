using static System.Random;
using static System.Math;
using System;

public static class mc{
	public static (double, double) quasimc(Func<vector,double> intf, vector a, vector b, int N){
		int n = a.size;
		double V = 1;
		for(int i=0; i<n; i++){
			V*=b[i]-a[i];
		}
		vector x = new vector(n);
		Random rand = new Random();
		double sum = 0;
		double sqsum = 0;
		for(int i=0; i<N; i++){
			vector quasiR = halton(i,n);
			for(int j=0; j<n; j++){
				x[j]=a[j]+quasiR[j]*(b[j]-a[j]);
			}
			double fx = intf(x);
			sum += fx;
			sqsum += fx*fx;
		}
		double mean = sum/N;
		double sigma = Sqrt(sqsum/N - mean*mean);
		return(mean*V, sigma*V/Sqrt(N));	
	}

	public static vector halton(int n, int d){
		vector x = new vector(d);
		int[] base_ = new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
		for(int i=0; i<d; i++){
			x[i] = corput(n,base_[i]);
		}
		return x;
	}

	public static double corput(int n, int base_){
		double q=0;
		double bk=1.0/base_;
		while(n>0){
			q+=(n%base_)*bk;
			n/=base_;
			bk/=base_;
		}
		return q;
	}
}
