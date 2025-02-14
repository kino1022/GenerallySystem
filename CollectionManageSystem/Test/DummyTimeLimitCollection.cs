using GenerallySys.Definition;
using System;
using UnityEngine;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys.Test {
	public class DummyTimeLimitCollection : A_Collection {

		private float _timeLimit = 0.0f;
		/// <summary>
		/// 補正値の残り時間
		/// </summary>
		public float timeLimit {
			get { return _timeLimit; }
			set {
				_timeLimit = value;
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="duration"></param>
		public DummyTimeLimitCollection (CollectionValueType type,float value,float duration) {

		}

		private async void
	}
}