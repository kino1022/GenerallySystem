using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.MoveControlSys {
    /// <summary>
    /// 移動方向ベクトルと移動量の大きさをかけ合わせた移動量の管理を行うクラスの基底クラス
    /// </summary>
    public abstract class A_MoveValueManager : MonoBehaviour {
        /// <summary>
        /// 移動量
        /// </summary>
        public Vector3 TotalMoveValue;
    }
}