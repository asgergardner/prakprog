using static System.Math;

public class evd{
	public static void timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta);
		double s = Sin(theta);
		int n = A.size1;
		double Aip;
		double Aiq;
		for(int i=0; i<n; i++){
			Aip = A[i,p];
			Aiq = A[i,q];
			A[i,p] = c*Aip - s*Aiq;
			A[i,q] = s*Aip + c*Aiq;
		}
	} 

	public static void Jtimes(matrix A, int p, int q, double theta){
		double c = Cos(theta);
                double s = Sin(theta);
		int n = A.size1;
		double Apj;
		double Aqj;
		for(int j=0; j<n; j++){
			Apj = A[p,j];
			Aqj = A[q,j];
			A[p,j] = c*Apj + s*Aqj;
			A[q,j] = -s*Apj + c*Aqj;	
		}
	}

	public static (vector, matrix) JacobiDiag(matrix A){
		int n = A.size1;
		vector e = new vector(n);
		matrix V = new matrix(n,n);

		for(int i=0; i<n; i++){e[i] = A[i,i];}

		for(int i=0; i<n; i++){
			V[i,i] = 1.0;
			for(int j=i+1; j<n; j++){
				V[i,j] = 0;
				V[j,i] = 0;
			}
		}
		
		int sweeps=0;
		bool changed;
		do{
			sweeps++;
			System.Console.WriteLine($"sweep nr {sweeps}");
			changed = false;
			for(int p=0; p<n-1; p++){
				for(int q=p+1; q<n; q++){
					double Apq = A[p,q];
					double App = A[p,p];
					double Aqq = A[q,q];
					double theta = 0.5*Atan2(2*Apq, Aqq-App);
					double c = Cos(theta);
					double s = Sin(theta);
					double RotApp = c*c*App - 2*s*c*Apq + s*s*Aqq;
					double RotAqq = s*s*App + 2*s*c*Apq + c*c*Aqq;
					if(RotApp != App || RotAqq != Aqq){
						changed = true;
						e[p] = RotApp;
						e[q] = RotAqq;
						timesJ(A,p,q,theta);
						Jtimes(A,p,q,-theta);
						timesJ(V,p,q,theta);

					}	
				}
			}
		}while(changed);

		return (e,V);	
	}
}
