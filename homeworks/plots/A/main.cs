using System;
using static System.Console;

class main{
	public static void Main(){
		for(double x=-1;x<=1;x+=1.0/8){
			WriteLine($"{x}	{functions.erf(x)}");
		}	
	}
}
