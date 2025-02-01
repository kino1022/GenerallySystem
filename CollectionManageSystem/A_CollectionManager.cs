using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.CollectionManageSys {
	/// <summary>
	/// �␳�l���Ǘ�����R���|�[�l���g�̊��N���X
	/// </summary>
	public abstract class A_CollectionManager : MonoBehaviour {
		/// <summary>
		/// ���ݓ����Ă���␳�l�̃��X�g
		/// </summary>
		private List<A_Collection> _collections = new List<A_Collection>();


		private void Start() {

		}

		private void Update() {

		}

		/// <summary>
		/// �␳�l���X�g������L���łȂ��␳�l��T���ď��O���郁�\�b�h
		/// </summary>
		private void CheckEnableCollection () {
			for (int i = 0; i < _collections.Count; i++) {
				if (!_collections[i].enable) {
					_collections.RemoveAt(i);
				}
			}
		}
		/// <summary>
		/// �␳�l���X�g���Q�Ƃ��ĕ␳�l�̍��v�l��Ԃ����\�b�h
		/// </summary>
		/// <returns></returns>
		private float CalucrationTotalValue () {
			float totalValue = 0.0f;
			foreach (A_Collection collection in _collections) {
				totalValue += collection.collection;
			}
			return totalValue;
		}

		/// <summary>
		/// �␳�l�̃��Z�b�g���s�����\�b�h
		/// </summary>
		public void ResetCollections () {
			_collections.Clear();
		}
	}
}