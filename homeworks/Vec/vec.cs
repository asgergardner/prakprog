using System;

public class vec{
	
	// Part A
	public double x;
	public double y;
	public double z;
	
	public vec(){
		x = 0;
		y = 0;
		z = 0;
	}	

	public vec(double xval, double yval, double zval){
		x = xval;
		y = yval;
		z = zval;
	
	}

	public static vec operator *(vec v, double c){
		return new vec(c*v.x, c*v.y, c*v.z);
	}

	public static vec operator *(double c, vec v){
		return v*c; 
	}

	public static vec operator +(vec v, vec u){
		return new vec(v.x + u.x, v.y + u.y, v.z + u.z);
	}

	public static vec operator -(vec v, vec u){
		return new vec(v.x - u.x, v.y - u.y, v.z - u.z);
	}

	public static vec operator -(vec u){
		return new vec(-u.x, -u.y, -u.z);
	}

	public void print(string s){
		Console.Write(s);
		Console.WriteLine($"({x}, {y}, {z})");
	}

	public void print(){
		this.print("");
	}
	
	// Part B

	public static vec dot(vec v, vec u){
		return new vec(v.x * u.x, v.y * u.y, v.z * u.z);
	}

	public static vec cross(vec v, vec u){
		return new vec((v.y * u.z) - (v.z * u.y), (v.z * u.x) - (v.x * u.z), (v.x * u.y) - (v.y * u.x));
	}
	
	public static double norm(vec v){
		return Math.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
	}

	public override string ToString(){
		return $"({this.x}, {this.y}, {this.z})";
	}

	// Part C
	
	public bool approx(vec other){
		return ((Double.Epsilon >= (this.x - other.x)) && ((this.x - other.x) >= 0)) && ((Double.Epsilon >= (this.y - other.y)) && ((this.y - other.y) >= 0)) && ((Double.Epsilon >= (this.z - other.z)) && ((this.z - other.z)>= 0));   
	}

	public static bool approx(vec u, vec v){
		return u.approx(v);
	}
}
