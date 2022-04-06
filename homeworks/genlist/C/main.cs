using static System.Console;
using System;

class main{
	public static void Main(){
       		var list = new genlist<double>();
		
		for(double x=1; x<=50; x++){
			if(x%5==0){list.push(x);}
		}
		
		WriteLine("Initial list of numbers:");
		for(int i=0; i<list.size; i++){
			var elem = list.data[i];
			WriteLine($"{elem}");
        	}
		
		WriteLine($"\nsize: {list.size}");
		WriteLine("**removing entries**");
		list.remove(9);
		
		WriteLine($"size: {list.size} \n");

		for(int i=0; i<list.size; i++){
                        var elem = list.data[i];
                        WriteLine($"{elem}");
                }
	}
}
		
