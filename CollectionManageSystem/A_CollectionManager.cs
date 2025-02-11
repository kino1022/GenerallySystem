using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// �␳�l���Ǘ�����R���|�[�l���g�̊��N���X
	/// </summary>
	public abstract class A_CollectionManager : MonoBehaviour {
		/// <summary>
		/// ���ݓ����Ă���␳�l�̃��X�g
		/// </summary>
		private List<A_Collection> _collections = new List<A_Collection>();

		private float _totalRatio = 0.0f;
		/// <summary>
		/// �����^�␳�l�̍��v�̒l
		/// </summary>
		public float totalRatoio {
			get { return _totalRatio; }
			set { 
				_totalRatio = value;
				wasChanged?.Invoke(_totalRatio, _totalFixed);
			}
		}

		private float _totalFixed = 0.0f;
		/// <summary>
		/// �Œ�l�^�␳�l�̍��v�l
		/// </summary>
		public float totalFixed {
			get { return _totalFixed; }
			set { 
				_totalFixed = value;
				wasChanged?.Invoke(_totalRatio,_totalFixed);
			}
		}

		/// <summary>
		/// �␳�l�̕ω������������ۂɔ��΂����C�x���g�A�����͏��Ɂi_totalRatio,_totalFixed�j
		/// </summary>
		public event Action<float,float> wasChanged;

		private void Start() {

		}

		private void Update() {

		}

		/// <summary>
		/// �␳�l���X�g���Q�Ƃ��ĕ␳�l�̍��v�l��Ԃ����\�b�h
		/// </summary>
		/// <returns></returns>
		private void CalucrationTotalValue () {

		}

		/// <summary>
		/// �␳�l�̃��Z�b�g���s�����\�b�h
		/// </summary>
		public void ResetCollections () {
			_collections.Clear();
		}
	}
}