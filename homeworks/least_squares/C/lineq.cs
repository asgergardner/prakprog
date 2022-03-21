using static System.Math;

public static class lineq{
	
	public static void QRGSdecomp(matrix A, matrix R){
		int n = A.size1;
		int m = A.size2;
		for(int i=0; i<m; i++){
			vector ai = A[i]; 
			R[i,i] =  Sqrt(ai.dot(ai));
			A[i] = ai/R[i,i];
			for(int j=i+1; j<m; j++){
				vector qi = A[i];
				vector aj = A[j];
				R[i,j] = qi.dot(aj);
				A[j] = aj-qi*R[i,j];
			}
		}
	}

	public static vector QRGSsolve(matrix Q, matrix R, vector b){
		matrix QT = Q.transpose();
		vector x = QT*b;
		backsub(R, x);
		return x;
	}

	public static void backsub(matrix U, vector c){
		for(int i=c.size-1; i>=0; i--){
			double sum = 0;
			for(int k=i+1; k<c.size; k++){
				sum+=U[i,k]*c[k];
			}
		c[i] = (c[i]-sum)/U[i,i];
		}
	}

	public static matrix QRGSinverse(matrix Q, matrix R){
		int n = R.size1;
		int m = R.size2;
		matrix Inv = new matrix(n,m);	
		matrix I = Identity(n,m);
		for(int i=0; i<m; i++){
			vector ei = I[i];
			vector xi = QRGSsolve(Q, R, ei);
			Inv[i] = xi;
		}

		return Inv;
	}

	public static matrix Identity(int n, int m){
		matrix I = new matrix(n,m);
                for(int i=0; i<n; i++){
                        for(int j=0; j<m; j++){
                                if(i==j){
                                        I[i,j] = 1;
                                }
                                else{I[i,j] = 0;}
                        }

                }
		return I;
	}
}
