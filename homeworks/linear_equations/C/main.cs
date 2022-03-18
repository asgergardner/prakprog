using System;
using static System.Console;
using static System.Random;
using System.Collections.Generic;
using static System.DateTime;

class main{
	public static void Main(){
		/*
		TestDecomp();
		TestSolver();
		TestInverse();
		*/
		TestTime();	
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
                matrix R = new matrix(n,m);
                lineq.QRGSdecomp(A, R);
                matrix Q = A.copy();

                WriteLine("QRGS decomposed matrices:");
                WriteLine("Q:");
                Q.print();
                WriteLine("R:");
                R.print();

                matrix I = lineq.Identity(m,m);

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
                matrix R = new matrix(n,m);
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

	public static void TestInverse(){
		WriteLine("TESTING INVERSE");
		Random rand = new Random();
                int n=5;
                int m=n;
                int N=11;
                matrix A = new matrix(n,m);
                matrix R = new matrix(n,m);
                for(int i=0; i<n; i++){
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(N);
                        }
                }

		matrix A_copy = A.copy();
		lineq.QRGSdecomp(A, R);
		matrix Q = A;
		
		WriteLine($"Randomly generated {n} by {m} matrix A:");
		A_copy.print();

		matrix B = lineq.QRGSinverse(Q,R);

		WriteLine($"Inverse of A:");
		B.print();
		
		matrix I = lineq.Identity(n,m);
		matrix AB = A_copy*B;
		WriteLine($"AB is (approx) the identity: {AB.approx(I)} \n");
	}
	

	public static void TestTime(){
		Random rand = new Random();
		List<matrix> mlist = new List<matrix>();
		List<matrix> rlist = new List<matrix>();
		
		int stepSize = 10;
		int endSize = 500;
		for(int i=stepSize; i<=500; i+=stepSize){
			int n = i;
			matrix m = new matrix(n,n);
			matrix r = new matrix(n,n);
			for(int j=0; j<n; j++){
                        	for(int k=0; k<n; k++){
                       		m[j,k] = rand.Next(11);
                        	}
                	}
			mlist.Add(m);
			rlist.Add(r);
		}

		for(int i=0; i<endSize/stepSize-stepSize; i++){
			matrix A = mlist[i];
			matrix R = rlist[i];
			
			double tBefore = DateTime.Now.Ticks;
			lineq.QRGSdecomp(A ,R);
			double tAfter = DateTime.Now.Ticks;
			double time = tAfter-tBefore;
			if(time>0){WriteLine($"{(i+stepSize)} {time}");}
		}
	}
}
