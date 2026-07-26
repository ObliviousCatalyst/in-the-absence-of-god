using UnityEngine;

public class inventory {
	public class item {
		public string name;
		public item (string name) {
			this.name = name;
		}
	}
	
	public class keyClass {
		public object[] items = new object[] {};
		
		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}

	public class limitedClass {
		//---------------------------------V this controlls the maximum number of items
		public object[] items = new object[4];

		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}
	
	public class unlimitedClass {
		public object[] items = new object[] {};
		
		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}

	public class largeClass {
		public object item;
		
		public void add(item obj) {
			item = obj;
		}

		public void remove() {
			item = null;
		}
	}
	public keyClass key = new keyClass();
	public limitedClass limited = new limitedClass();
	public unlimitedClass unlimited = new unlimitedClass();
	public largeClass large = new largeClass();
}