using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.MoveControlSys {
    /// <summary>
    /// キャラクターの移動量の大きさを管理するコンポーネントに対して実装するインターフェース
    /// </summary>
    public interface I_MovementManager {
        /// <summary>
        /// キャラクターの移動量の大きさ
        /// </summary>
        public float Movement { get; set; }
        /// <summary>
        /// 移動量の大きさを渡す対象のA_MoveValueManager
        /// </summary>
        public A_MoveValueManager Manager { get; set; }
    }
}