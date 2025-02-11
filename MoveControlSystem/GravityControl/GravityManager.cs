using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.MoveControlSys.GravitiySys {
	/// <summary>
	/// 重力の移動量を管理するマネージャーコンポーネント
	/// </summary>
	public class GravityManager : A_MoveValueManager {
		/// <summary>
		/// 働く重力の大きさ
		/// </summary>
		private float _gravityValue = Physics.gravity.y;

		[SerializeField] private Boolean _enableGravity = true;
		/// <summary>
		/// 重力を無効化するかどうかの真偽値（モーション中とかはfalseにする）
		/// </summary>
		public Boolean enableGravity {
			get { return _enableGravity; }
			set { _enableGravity = value; }
		}

		private Vector3 _direction = new Vector3(0.0f, 1.0f, 0.0f);
		/// <summary>
		/// 重力の働く方向
		/// </summary>
		public Vector3 direction {
			get { return _direction; }
			set { _direction = value.normalized; }
		}


		/// <summary>
		/// 重力補正値の管理コンポーネント
		/// </summary>
		private GravityCollectionManager _gravityCollection;

		private CharacterController _controller;

		void Start () {
			//CharacterControllerの取得処理
			_controller = GetComponent<CharacterController>();
			if (_controller == null) {
				Debug.Log("CharacterControllerの取得に失敗しました");
			}
			else {
				Debug.Log("characterContorllerの取得に成功しました");
			}

			//補正値管理マネージャーの取得処理
			_gravityCollection = GetComponent<GravityCollectionManager>();
			if (_gravityCollection == null) {
				Debug.Log("重力補正値管理マネージャーコンポーネントの取得処理に失敗しました");
			}
			else {
				Debug.Log("重力補正値管理マネージャーコンポーネントの取得処理に成功しました");
			}
		}

		void Update () {

		}
	}
}