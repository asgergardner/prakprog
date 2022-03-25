using System;
using static System.Console;

class main{
	public static void Main(){
		// Generating symmetric matrix A
		int n = 5;
		int m = n;
		matrix A = new matrix(n,m);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<=i; j++){
				A[i,j] = rand.Next(11);
				A[j,i] = A[i,j];
			}
		}
		
		WriteLine($"Random {n} by {m} symmetric matrix A:");
		A.print();
		WriteLine("\n");
		
		vector e;
		matrix V;
		WriteLine("**diagonalizing**");
		matrix A_copy = A.copy();
		(e,V) = evd.JacobiDiag(A);
		matrix D = A.copy();
		WriteLine("\n");

		WriteLine("Diagonalized matrix:");
		D.print();
		WriteLine("\n");

		WriteLine("Vector of eigenvalues and matrix of eigenvectors:");
		WriteLine("e:");
		e.print();
		WriteLine("V:");
		V.print();
		WriteLine("\n");

		matrix VTV = (V.transpose())*V;
		WriteLine("V^TV:");
		VTV.print();
		WriteLine("\n");

		matrix VVT = V*(V.transpose());
		WriteLine("VV^T:");
		VVT.print();
		WriteLine("\n");

		WriteLine($"V^TAV equals D: {(V.transpose()*A_copy*V).approx(D)}");
		WriteLine("\n");

		WriteLine($"VDV^T equals A: {(V*D*(V.transpose())).approx(A_copy)}");
		WriteLine("\n");
	}
}
