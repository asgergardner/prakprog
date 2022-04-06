using static System.Console;
using System;

class main{
	public static void Main(){
		var list = new genlist<double[]>();
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line!=null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.push(numbers);
       			}
			
		for(int i=0;i<list.size;i++){
			var numbers = list.data[i];
			foreach(var number in numbers){
				WriteLine($"{number}");
			}
        	}
	}
}
		
