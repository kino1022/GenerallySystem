using GenerallySys.Definition;
using System;
using UnityEngine;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys.Test {
	/// <summary>
	/// �␳�l�N���X�̃e�X�g�p�_�~�[�N���X�i�i���ɂȂ�̂œK�X���Ƃ����j
	/// </summary>
	public class DummyCollection : A_Collection {
		
		public DummyCollection(CollectionValueType type,float value) {
			this.type = type;
			collection = value;
		}


	}
}