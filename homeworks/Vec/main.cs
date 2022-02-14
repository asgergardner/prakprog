using static System.Console;

public static class main{
	public static int Main(){
		
		// TEST VARIABLES
		vec v = new vec(1,2,3);
		vec u = new vec(3,2,1);
		vec xHat = new vec(1,0,0);
		vec yHat = new vec(0,1,0);
		vec zero = new vec(0,0,0);
		
		// TESTING METHODS
		v.print("v = ");
		
		vec multiplied = v*2;
		WriteLine($"{v.ToString()} *2: {multiplied.ToString()}");
		
		vec added = v+u;
		WriteLine($"Sum of {v.ToString()} and {u.ToString()}: {added.ToString()}");
		
		vec subtracted = v-u;
		WriteLine($"{v.ToString()} minus {u.ToString()}: {subtracted.ToString()}");
		
		vec minusSelf = v-v;
		WriteLine($"Vector minus self equals zero vector: {minusSelf.Equals(zero)}");
		
		vec inverted = -v;
		WriteLine($"Inversion of {v.ToString()}: {inverted.ToString()}");
		
		vec vDoubleInv = -(-v);
		WriteLine($"Doubly inverted vector equal to initial vector: {vDoubleInv.Equals(v)}");
		
		vec invZero = -zero;
		WriteLine($"Inversion of zero vector: {invZero.ToString()}");
		
		double dotted = vec.dot(v, u);
		WriteLine($"Dot product of {v.ToString()} and {u.ToString()}: {dotted.ToString()}");
		
		double xDotY = vec.dot(xHat, yHat);
		WriteLine($"Dot product of orthogonal vectors is zero: {xDotY == 0}");
			
		vec crossed = vec.cross(v,u);
		WriteLine($"Cross product of {v.ToString()} and {u.ToString()}: {crossed.ToString()}");
		WriteLine($"Cross product is orthogonal to initial vectors: {vec.dot(v,crossed) == 0}, {vec.dot(u, crossed) == 0}");
		
		double normV = vec.norm(v);
		WriteLine($"Norm of v: {normV.ToString()}");
		WriteLine($"Norm of zero vector is 0: {vec.norm(zero) == 0}");
		
		vec vModEps = v*(1+1e-9);
		WriteLine($"{v.ToString()} is approximately equal to {v.ToString()} * (1+eps): {vModEps.approx(v)}");
		vec vModEps10 = v*(1+1e-10);
		WriteLine($"{v.ToString()} is approximately equal to {v.ToString()} * (1+eps/10): {vModEps10.approx(v)}");		
		WriteLine($"(1,2,3) is approximately (3,2,1): {v.approx(u)}");
		
		return 0;
	}
}
