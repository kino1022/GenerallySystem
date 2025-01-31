using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GenerallySys.MoveControlSys.InertialSys {
    /// <summary>
    /// 慣性の基底クラス
    /// </summary>
    public abstract class A_Inertial {

        private Vector3 _totalMoveValue = Vector3.zero;
        /// <summary>
        /// この慣性の持つ総合の移動量
        /// </summary>
        public Vector3 totalMoveValue {
            get { return _totalMoveValue; }
            set { _totalMoveValue = value; }
        }

        private Vector3 _direction = Vector3.zero;
        /// <summary>
        /// 慣性の働く方向の標準化ベクトル
        /// </summary>
        public Vector3 direction {
            get { return _direction; }
            set {
                _direction = value.normalized;
                totalMoveValue = movement * direction;
            }
        }

        private float _movement = 0.0f;
        /// <summary>
        /// 慣性の大きさ
        /// </summary>
        public float movement {
            get { return _movement; }
            set {
                movement = value;
                totalMoveValue = _movement * direction;
            }
        }

        /// <summary>
        /// 慣性量管理クラスをインスタンスする領域
        /// </summary>
        private InertialMovement _inertialMovement;

        /// <summary>
        /// 慣性が有効かどうか
        /// </summary>
        public Boolean enable = true;

        public A_Inertial (Vector3 setDirection,float setMovement,float setDumping) {
            direction = setDirection;
            _inertialMovement = new InertialMovement(this, setMovement, setDumping);
        }
    }
}