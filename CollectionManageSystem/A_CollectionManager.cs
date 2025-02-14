using GenerallySys.CollectionManageSys.Test;
using GenerallySys.Definition;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GenerallySys.Definition.CollectionValueType;
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
		public float totalRatio {
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
		/// �␳�l�̐������s�����\�b�h�i�W�F�l���b�N��p���������I�Ȃ��̂ł���׈ˑ��͋֕��j
		/// �L�q��F_collection.CreateCollection(() => new DummyCollection(GenerallySys.Definition.CollectionValueType.Ratio, 10.0f));
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="constructor"></param>
		public void CreateCollection<T> (Func<T> constructor) where T : A_Collection {
			T newCollection = constructor();
			_collections.Add(newCollection);
			newCollection.wasReleased += GetWasReleased;
		}

		/// <summary>
		/// �␳�l�̏��ŃC�x���g�����΂��ꂽ�ۂɌĂяo����郁�\�b�h
		/// </summary>
		/// <param name="release"></param>
		private void GetWasReleased (A_Collection release) {
			foreach (var collection in _collections) {
				if (collection == release) {
					_collections.Remove(release);
					release.wasReleased -= GetWasReleased;
					break;
				}
			}
			Debug.Log("�␳�l�N���X�̏��O�������I�����܂���");
		}

		/// <summary>
		/// �␳�l�̑��ʂ��Z�o���郁�\�b�h�B�n���l�͎Q�ƌ^�Ȃ̂ŁA�K�؂Ȃ��̂����鎖
		/// </summary>
		/// <param name="ratio"></param>
		/// <param name="fix"></param>
		/// <param name="index"></param>
		private void CalculationTotalValue() {

		}
	}
}