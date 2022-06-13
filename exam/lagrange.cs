using System;
using static roots;

public static class lagrange{
	
	public static (double, vector) EigenSearch(matrix A, double lambdaInit){
		int n = A.size1;
		Func<vector,vector> f = delegate(vector x){
			vector fres = new vector(n+1);
			vector v = new vector(n);
			for(int i=0; i<n; i++){
				v[i] = x[i];
			}
			vector AvLv = A*v -x[n]*v;
			for(int j=0; j<n; j++){
				fres[j] = AvLv[j]; 
			}
			fres[n] = v.dot(v)-1;
			return fres;};

		vector x0 = new vector(n+1);
		for(int k=0; k<n; k++){
			x0[k] = 1;
		}
		x0[n] = lambdaInit;
		vector fRoot = nroots(f,x0,A);
		vector vres = new vector(n);
		for(int l=0; l<n; l++){
			vres[l] = fRoot[l];
		}
		return (fRoot[n],vres);
	}
		
}
