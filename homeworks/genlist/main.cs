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

		printlist(list);
		WriteLine(list);
		list.remove(1);
		printlist(list);
	}

	public static void printlist(genlist<double[]> list){
                        for(int i=0;i<list.size;i++){
                                var numbers = list.data[i];
                                foreach(var number in numbers)Write($"{number:e} ");
                                        WriteLine();
                        }
    	}		

}
		
