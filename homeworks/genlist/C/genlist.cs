public class genlist<T> {
	public class list<T>{
		public T[] data;
		public int size=0;
		public int capacity=8;	
		public genlist() {data = new T[capacity];}
		
		public void push(T item){ 
			if(size==capacity){
				T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
		}
		data[size]=item;
		size++;	
		}

		public void remove(int i){
			if(i<0 || i>=size){System.Console.Error.WriteLine($"REMOVE: WRONG INDEX:{i}");return;}
			for(int j=i;j<size-1;j++){
				data[j] = data[j+1];
				data[j+1] = default (T);
			}
			size-=1;
		}

	}

	public class node<T>
}
