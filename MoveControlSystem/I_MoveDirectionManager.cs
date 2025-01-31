using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.MoveControlSys {
    /// <summary>
    /// キャラクターの移動方向を管理するクラスに対して実装するインターフェース
    /// </summary>
    public interface I_MoveDirectionManager {
        /// <summary>
        /// キャラクターの移動方向
        /// </summary>
        public Vector3 MoveDirection { get; set; }
        /// <summary>
        /// 移動方向のベクトルを渡すマネージャークラス
        /// </summary>
        public A_MoveValueManager Manager { get; set; }
    }
}