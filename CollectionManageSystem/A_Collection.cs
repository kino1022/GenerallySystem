using GenerallySys.Definition;
using GenerallySys.MoveControlSys.GravitiySys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys {
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
		/// 補正値が消滅した際に呼び出されるイベント
		/// </summary>
		public UnityEvent wasReleased;
	}
}