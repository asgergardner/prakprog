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

	public static double dot(vec v, vec u){
		return v.x * u.x + v.y * u.y + v.z * u.z;
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
	
	static bool approx(double a, double b, double tau = 1e-9, double eps = 1e-9){
		if(Math.Abs(a-b)<tau){return true;}
		if(Math.Abs(a-b)/(Math.Abs(a)-Math.Abs(b))<eps){return true;}
		return false;
	}

	public bool approx(vec other){
		if(!approx(this.x, other.x)){return false;}
		if(!approx(this.y, other.y)){return false;}
		if(!approx(this.z, other.z)){return false;}
		return true;
	}

	public bool Equals(vec other){
		if((this.x == other.x) && (this.y == other.y) && (this.z == other.z)){return true;}
		return false;
	}
}
