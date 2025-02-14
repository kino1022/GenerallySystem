using GenerallySys.Definition;
using GenerallySys.MoveControlSys.GravitiySys;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// 補正値の基底クラス。補正値の自己破壊とかコンストラクタとかは継承先で組むこと。
	/// </summary>
	public abstract class A_Collection {
		/// <summary>
		/// 補正値の値の分類
		/// </summary>
		public CollectionValueType type;

		private float _collection = 0.0f;
		/// <summary>
		/// 補正値の値
		/// </summary>
		public float collection {
			get { return _collection; }
			set { _collection = value; }
		}

		/// <summary>
		/// 補正値が無効化された際に発火されるイベント
		/// </summary>
		public event Action<A_Collection> wasReleased;
	}
}