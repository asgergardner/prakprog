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
}
