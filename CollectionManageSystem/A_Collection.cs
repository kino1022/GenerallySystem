using GenerallySys.MoveControlSys.GravitiySys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// �␳�l�̊��N���X
	/// </summary>
	public abstract class A_Collection {

		private float _collection = 0.0f;
		/// <summary>
		/// �␳�l�̗�(%�ł͂Ȃ������Œ�`���鎖)
		/// </summary>
		public float collection {
			get { return _collection; }
			set { _collection = value; }
		}

		/// <summary>
		/// �␳�l���L�����ǂ����̐^�U�l
		/// </summary>
		public Boolean enable = true;
	}
}