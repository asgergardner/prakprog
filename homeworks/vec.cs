public class vec{
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

	public static vec dot(vec v, vec u){
		return new vec(v.x * u.x, v.y * u.y, v.z * u.z);
	}

	public static vec cross(vec v, vec u){
		return new vec((v.y * u.z) - (v.z * u.y), (v.z * u.x) - (v.x * u.z), (v.x * u.y) - (v.y * u.x));
	}
	
	public static double norm(vec v){
		return 
	}
}
