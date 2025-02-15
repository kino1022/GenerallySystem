using GenerallySys.CollectionManageSys.Test;
using GenerallySys.Definition;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GenerallySys.Definition.CollectionValueType;
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
		public float totalRatio {
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


		/// <summary>
		/// 補正値の生成を行うメソッド（ジェネリックを用いた試験的なものである為依存は禁物）
		/// 記述例：_collection.CreateCollection(() => new DummyCollection(GenerallySys.Definition.CollectionValueType.Ratio, 10.0f));
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="constructor"></param>
		public void CreateCollection<T> (Func<T> constructor) where T : A_Collection {
			T newCollection = constructor();
			_collections.Add(newCollection);
			newCollection.wasReleased += GetWasReleased;
			CalculationTotalValue();
		}

		/// <summary>
		/// 補正値の消滅イベントが発火された際に呼び出されるメソッド
		/// </summary>
		/// <param name="release"></param>
		private void GetWasReleased (A_Collection release) {
			foreach (var collection in _collections) {
				if (collection == release) {
					_collections.Remove(release);
					release.wasReleased -= GetWasReleased;
					break;
				}
			}
			CalculationTotalValue();
			Debug.Log("補正値クラスの除外処理が終了しました");
		}

		/// <summary>
		/// 補正値の合計値を更新するメソッド
		/// </summary>
		private void CalculationTotalValue() {

			float ratioValue = 0.0f;
			float fixValue = 0.0f;

			foreach (A_Collection collection in _collections) {
				if (collection.type == Ratio) ratioValue += collection.collection;
				else if (collection.type == Fixed) fixValue += collection.collection;
			}

			if (totalRatio != ratioValue) totalRatio = ratioValue;
			if (totalFixed != fixValue) totalFixed = fixValue;
		}

		/// <summary>
		/// 与えられた値に補正値の補正を施して返すメソッド
		/// </summary>
		/// <param name="baseValue"></param>
		/// <returns></returns>
		public float CalcurationCollectionedValue (float baseValue) {
			return baseValue * totalRatio + totalFixed;
		}

		/// <summary>
		/// 補正値のリセットを行うメソッド
		/// </summary>
		public void ClearCollection () {
			foreach (A_Collection collection in _collections) {
				_collections.Remove(collection);
				collection.wasReleased -= GetWasReleased;
			}
		}

		/// <summary>
		///	引数で指定した補正値が存在したならtrueを返すメソッド
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public Boolean FetchTargetCollection (A_Collection target) {
			foreach (A_Collection collection in _collections) {
				if (collection == target) return true;
			}
			return false;
		}
	}
}