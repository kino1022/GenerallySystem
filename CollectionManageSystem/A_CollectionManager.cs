using GenerallySys.CollectionManageSys.Test;
using GenerallySys.Definition;
using JetBrains.Annotations;
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
		/// 補正値の生成を行うメソッド（ジェネリックを用いた試験的なものである為依存は禁物）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="constructor"></param>
		public void CreateCollection<T> (Func<T> constructor) where T : A_Collection {
			T newCollection = constructor();
			_collections.Add(newCollection);
			newCollection.wasReleased += GetWasReleased;
		}

		/// <summary>
		/// 補正値の消滅イベントが発火された際に呼び出されるメソッド
		/// </summary>
		/// <param name="release"></param>
		private void GetWasReleased (A_Collection release) {
			foreach (var collection in _collections) {
				if (collection == release) {
					_collections.Remove(release);
					break;
				}
			}
			Debug.Log("補正値クラスの除外処理が終了しました");
		}

		/// <summary>
		/// 補正値総量の算出メソッド（代入型の概念を用いた試験的なものなので依存しない事）
		/// </summary>
		/// <param name="ratio"></param>
		/// <param name="fix"></param>
		/// <param name="index"></param>
		private void ClucrationTotalValue (ref float ratio,ref float fix,List<A_Collection> index) {

			var rat = 0.0f;
			var fixe = 0.0f;

			foreach (var collection in index) {
				if (collection.type == CollectionValueType.Ratio) {
					rat += collection.collection;
				}
				else {
					fixe += collection.collection;
				}
			}

			if (ratio != rat) ratio = rat;
			if (fix != fixe) fix = fixe;
		}
	}
}