class leastsq{
	public static (vector, matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n = n.size;
		int m = fs.size;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i] = y[i]/dy[i];
			for(int j=0; j<m; j++){
				A[i,j] = fs[j](x[i])/dy[i]; 
			}
		}
		matrix R = new matrix(m,m);
		lineq.QRGSdecomp(A,R);
		Q = A;
		lineq.QRGSsolve(Q,R,b);

	}
}
