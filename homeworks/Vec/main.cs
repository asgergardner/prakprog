using static System.Console;

public static class main{
	public static int Main(){
		vec v = new vec(1,2,3);
		vec u = new vec(3,2,1);
		v.print("v = ");

		vec dotted = vec.dot(v, u);
		WriteLine($"Dot product of {v.ToString()} and {u.ToString()}: {dotted.ToString()}");
		
		vec crossed = vec.cross(v,u);
		WriteLine($"Cross product of {v.ToString()} and {u.ToString()}: {crossed.ToString()}");

		return 0;
	}
}
