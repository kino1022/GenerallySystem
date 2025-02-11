using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// 補正値を管理するコンポーネントの基底クラス
	/// </summary>
	public abstract class A_CollectionManager : MonoBehaviour {
		/// <summary>
		/// 現在働いている補正値のリスト
		/// </summary>
		private List<A_Collection> _collections = new List<A_Collection>();

		private float _totalRatio = 0.0f;
		/// <summary>
		/// 割合型補正値の合計の値
		/// </summary>
		public float totalRatoio {
			get { return _totalRatio; }
			set { 
				_totalRatio = value;
				wasChanged?.Invoke(_totalRatio, _totalFixed);
			}
		}

		private float _totalFixed = 0.0f;
		/// <summary>
		/// 固定値型補正値の合計値
		/// </summary>
		public float totalFixed {
			get { return _totalFixed; }
			set { 
				_totalFixed = value;
				wasChanged?.Invoke(_totalRatio,_totalFixed);
			}
		}

		/// <summary>
		/// 補正値の変化が発生した際に発火されるイベント、引数は順に（_totalRatio,_totalFixed）
		/// </summary>
		public event Action<float,float> wasChanged;

		private void Start() {

		}

		private void Update() {

		}

		/// <summary>
		/// 補正値リストを参照して補正値の合計値を返すメソッド
		/// </summary>
		/// <returns></returns>
		private void CalucrationTotalValue () {

		}

		/// <summary>
		/// 補正値のリセットを行うメソッド
		/// </summary>
		public void ResetCollections () {
			_collections.Clear();
		}
	}
}