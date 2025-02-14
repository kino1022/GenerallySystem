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
	/// �␳�l�̊��N���X�B�␳�l�̎��Ȕj��Ƃ��R���X�g���N�^�Ƃ��͌p����őg�ނ��ƁB
	/// </summary>
	public abstract class A_Collection {
		/// <summary>
		/// �␳�l�̒l�̕���
		/// </summary>
		public CollectionValueType type;

		private float _collection = 0.0f;
		/// <summary>
		/// �␳�l�̒l
		/// </summary>
		public float collection {
			get { return _collection; }
			set { _collection = value; }
		}

		/// <summary>
		/// �␳�l�����������ꂽ�ۂɔ��΂����C�x���g
		/// </summary>
		public event Action<A_Collection> wasReleased;
	}
}