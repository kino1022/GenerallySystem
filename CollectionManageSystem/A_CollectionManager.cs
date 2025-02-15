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
			CalculationTotalValue();
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
			CalculationTotalValue();
			Debug.Log("�␳�l�N���X�̏��O�������I�����܂���");
		}

		/// <summary>
		/// �␳�l�̍��v�l���X�V���郁�\�b�h
		/// </summary>
		private void CalculationTotalValue() {

			float ratioValue = 0.0f;
			float fixValue = 0.0f;

			foreach (A_Collection collection in _collections) {
				if (collection.type == Ratio) ratioValue += collection.collection;
				else if (collection.type == Fixed) fixValue += collection.collection;
			}

			if (totalRatio != ratioValue) totalRatio = ratioValue;
			if (totalFixed != fixValue) totalFixed = fixValue;
		}

		/// <summary>
		/// �^����ꂽ�l�ɕ␳�l�̕␳���{���ĕԂ����\�b�h
		/// </summary>
		/// <param name="baseValue"></param>
		/// <returns></returns>
		public float CalcurationCollectionedValue (float baseValue) {
			return baseValue * totalRatio + totalFixed;
		}

		/// <summary>
		/// �␳�l�̃��Z�b�g���s�����\�b�h
		/// </summary>
		public void ClearCollection () {
			foreach (A_Collection collection in _collections) {
				_collections.Remove(collection);
				collection.wasReleased -= GetWasReleased;
			}
		}

		/// <summary>
		///	�����Ŏw�肵���␳�l�����݂����Ȃ�true��Ԃ����\�b�h
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public Boolean FetchTargetCollection (A_Collection target) {
			foreach (A_Collection collection in _collections) {
				if (collection == target) return true;
			}
			return false;
		}
	}
}