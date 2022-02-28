using System;
using static System.Console;

class main{
	public static void Main(){
		int start = -5;
		int end = 5;
		double divisions = 10;
		for(double i=start;i<=end;i+=1.0/divisions){
			for(double j=start;j<=end;j+=1.0/divisions){
				complex x = new complex(i,j);
				complex gamma = functions.cgamma(x);
				double absgamma = cmath.abs(gamma);
				WriteLine($"{x.Re} {x.Im} {absgamma}");
			}
		}
	}
}
