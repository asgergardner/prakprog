using System;
using static System.Console;
using static System.Random;

class main{
	public static void Main(){
		/*
		//Testing decomposition
		int n = 6;
		int m = 4;
		matrix A = new matrix(n,m);

		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
			A[i,j] = rand.Next(11);
			}
		}
		matrix A_copy = A.copy();
		
		WriteLine($"Randomly generated {n} by {m} matrix:");
		A.print();

		WriteLine("**orthogonalizing**");	
		matrix R = new matrix(n,m);
		lineq.QRGSdecomp(A, R);
		matrix Q = A.copy();

		WriteLine("QRGS decomposed matrices:");
		WriteLine("Q:");
		Q.print();
		WriteLine("R:");
		R.print();
		
		matrix I = new matrix(m,m);
		for(int i=0; i<m; i++){
			for(int j=0; j<m; j++){
				if(i==j){I[i,j] = 1;}
				else{I[i,j] = 0;}
			}
		}

		matrix QTQ = Q.transpose()*Q;
		WriteLine($"Q^T*Q is (approx) the identity: {I.approx(QTQ)} \n");	

		WriteLine($"QR is (approx) equal to A: {A_copy.approx(Q*R)} \n");

		//Testing solver
		int n=5;
		int m=n;
		int N=11;
		matrix A = new matrix(n,m);
		matrix R = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i] = rand.next(N);
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(N);
                        }
                }
		A_copy = A.copy()
		lineq.QRGSdecomp(A, R);
		Q = A.copy();
		vector x = lineq.QRGSsolve(Q, R, b);
		WriteLine($"Checking Ax=b: {A_copy*x} {b}"); */

		TestDecomp();
		TestSolver();
	
	}
	public static void TestDecomp(){
		WriteLine("TESTING DECOMPOSITION");
		int n = 6;
                int m = 4;
                matrix A = new matrix(n,m);

                var rand = new Random();
                for(int i=0; i<n; i++){
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(11);
                        }
                }
                matrix A_copy = A.copy();

                WriteLine($"Randomly generated {n} by {m} matrix:");
                A.print();

                WriteLine("**orthogonalizing**");
                matrix R = new matrix(m,m);
                lineq.QRGSdecomp(A, R);
                matrix Q = A.copy();

                WriteLine("QRGS decomposed matrices:");
                WriteLine("Q:");
                Q.print();
                WriteLine("R:");
                R.print();

                matrix I = new matrix(m,m);
                for(int i=0; i<m; i++){
                        for(int j=0; j<m; j++){
                                if(i==j){I[i,j] = 1;}
                                else{I[i,j] = 0;}
                        }
                }

                matrix QTQ = Q.transpose()*Q;
                WriteLine($"Q^T*Q is (approx) the identity: {I.approx(QTQ)} \n");

                WriteLine($"QR is (approx) equal to A: {A_copy.approx(Q*R)} \n");
	}
	public static void TestSolver(){
		WriteLine("TESTING SOLVER");
		Random rand = new Random();
		int n=5;
                int m=n;
                int N=11;
                matrix A = new matrix(n,m);
                matrix R = new matrix(m,m);
                vector b = new vector(n);
                for(int i=0; i<n; i++){
                        b[i] = rand.Next(N);
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(N);
                        }
                }
		
		WriteLine($"Randomly generated {n} by {m} matrix:");
		A.print();
		WriteLine($"Randomly generated vector of dimension {n}:");
		b.print();
		
		WriteLine("**solving**");
                matrix A_copy = A.copy();
                lineq.QRGSdecomp(A, R);
                matrix Q = A.copy();
                vector x = lineq.QRGSsolve(Q, R, b);
		vector Ax = A_copy*x;

		WriteLine($"Ax is (approx) equal to b: {Ax.approx(b)} \n");
	}
}
