using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// 補正値を管理するコンポーネントの基底クラス
	/// </summary>
	public abstract class A_CollectionManager : MonoBehaviour {
		/// <summary>
		/// 現在働いている補正値のリスト
		/// </summary>
		private List<A_Collection> _collections = new List<A_Collection>();


		private void Start() {

		}

		private void Update() {

		}

		/// <summary>
		/// 補正値リスト内から有効でない補正値を探して除外するメソッド
		/// </summary>
		private void CheckEnableCollection () {
			for (int i = 0; i < _collections.Count; i++) {
				if (!_collections[i].enable) {
					_collections.RemoveAt(i);
				}
			}
		}
		/// <summary>
		/// 補正値リストを参照して補正値の合計値を返すメソッド
		/// </summary>
		/// <returns></returns>
		private float CalucrationTotalValue () {
			float totalValue = 0.0f;
			foreach (A_Collection collection in _collections) {
				totalValue += collection.collection;
			}
			return totalValue;
		}

		/// <summary>
		/// 補正値のリセットを行うメソッド
		/// </summary>
		public void ResetCollections () {
			_collections.Clear();
		}
	}
}