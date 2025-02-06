using GenerallySys.MoveControlSys.GravitiySys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// 補正値の基底クラス
	/// </summary>
	public abstract class A_Collection {

		private float _collection = 0.0f;
		/// <summary>
		/// 補正値の量(%ではなく小数で定義する事)
		/// </summary>
		public float collection {
			get { return _collection; }
			set { _collection = value; }
		}

		/// <summary>
		/// 補正値が有効かどうかの真偽値
		/// </summary>
		public Boolean enable = true;
	}
}