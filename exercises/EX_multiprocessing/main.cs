using System;
using System.Threading;
using static System.Console;

public class main{

	public class data{
		public int a;
		public int b;
		public double sum;
	}

	public static void Main(string[] args){
		data x = new data();
		data y = new data();
		int N = (int)1e8;
		if(args.Length>0){
			N = (int)double.Parse(args[0]);
		}
		WriteLine($"N={(float)N}");
		x.a = 1;
		x.b = N/2;
		y.a = N/2;
		y.b = N+1;
		Thread t1 = new Thread(harm);
		Thread t2 = new Thread(harm);
		t1.Start(x);
		t2.Start(y);
		t1.Join();
		t2.Join();
		WriteLine($"Harmonic sum from {1} to {N} = {x.sum + y.sum}");
	}

	public static void harm(object obj){
	data d = (data)obj;
	WriteLine($"harm: summing from {d.a} to {d.b}");
	d.sum = 0; 
	for(int i=d.a;i<d.b;i++){
		d.sum+=(double)1/i;
		}
	WriteLine($"harm: summing from {d.a} to {d.b} equals {d.sum}");	
	}
}
