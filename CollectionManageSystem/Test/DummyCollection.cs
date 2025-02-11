using GenerallySys.Definition;
using System;
using UnityEngine;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys.Test {
	/// <summary>
	/// 補正値クラスのテスト用ダミークラス（永続になるので適宜落とす事）
	/// </summary>
	public class DummyCollection : A_Collection {
		
		public DummyCollection(CollectionValueType type,float value) {
			this.type = type;
			collection = value;
		}


	}
}