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

		var intlist = new genlist<double[]>();
		double[] ints = new double[] {1,2,3,4,5};
		intlist.push(ints);

		WriteLine($"Integer list before removal:");
		intlist.print();
		intlist.remove(2);
		WriteLine($"Integer list after removal:");
	       	intlist.print();
	}
}
		
