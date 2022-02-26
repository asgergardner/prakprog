using System;
using static System.Console;

class main{
	public static void Main(){
		for(double x=-5;x<=5;x+=1.0/8){
			double gamma = functions.gamma(x, false);
			double lngamma = functions.gamma(x, true);
			WriteLine($"{x}	{gamma} {lngamma}");
		}	
	}
}
