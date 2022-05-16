using static System.Console;
using System;

class main{
	public static void Main(){
        	list<int> a = new list<int>();
                a.push(1);
                a.push(2);
                a.push(3);
                for( a.start(); a.current != null; a.next()){
                        WriteLine(a.current.item);
		}
	}
}
		
