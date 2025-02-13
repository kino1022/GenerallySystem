using System;
using UnityEngine;
using GenerallySys.CollectionManageSys;

namespace GenerallySys.Utility {
	public static class CollectionUtility {
		public static T CreateCollection<T> (Func<T> constructor) where T : A_Collection {
			return constructor();
		}
	}
}