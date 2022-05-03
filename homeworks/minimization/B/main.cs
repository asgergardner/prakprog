using System;
using static System.Console;
using static min;

class main{
	public static void Main(){
		Func<vector,double,vector> BW = delegate(vector param, double E){
			return param[0]/((E-param[1])*(E-param[1]) + param[2]*param[2]/4);

		};

		Func<vector,double> deviation = delegate(vector param){

			double res;
			for(int i=0; i<E.size(); i++){
				res+=((BW(param, E[i])-sigma[i])/dsigma)*((BW(param, E[i])-sigma[i])/dsigma)
			}
			return res
		}
				
	}
}
