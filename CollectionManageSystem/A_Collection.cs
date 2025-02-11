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
		/// �␳�l�����ł����ۂɌĂяo�����C�x���g
		/// </summary>
		public UnityEvent wasReleased;
	}
}