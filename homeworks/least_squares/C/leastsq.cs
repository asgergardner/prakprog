using System;
public class leastsq{
	public static (vector, matrix) lsfit(Func<double,double>[] fs, double[] x, double[] y, double[] dy){
		int n = x.Length;
		int m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i] = y[i]/dy[i];
			for(int j=0; j<m; j++){
				A[i,j] = fs[j](x[i])/dy[i]; 
			}
		}

		//QR decomposition
		matrix R = new matrix(m,m);
		lineq.QRGSdecomp(A,R);
		matrix Q = A;
	
		//Solving system
		vector c = lineq.QRGSsolve(Q,R,b);
		
		//Calculating covariance matrix
		matrix RR = new matrix(R.size2, R.size2);
		lineq.QRGSdecomp(R,RR);
		matrix Q_R = R;
		matrix invR = lineq.QRGSinverse(Q_R,RR);
		matrix S = invR*invR.transpose();
		return (c,S);
	}
}
