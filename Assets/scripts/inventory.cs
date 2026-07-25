using UnityEngine;

public class inventory : MonoBehaviour {
	public class item {
		item () {
			
		}
	}
	
	public class key {
		public object[] items = new object[] {};
		
		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}

	public class limited {
		//---------------------------------V this controlls the maximum nuber of items
		public object[] items = new object[4];

		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}
	
	public class unlimited {
		public object[] items = new object[] {};
		
		public void add(int index, item obj) {
			items[index] = obj;
		}

		public void remove(int index) {
			items[index] = null;
		}
	}

	public class large {
		public object item;
		
		public void add(item obj) {
			item = obj;
		}

		public void remove() {
			item = null;
		}
	}
}