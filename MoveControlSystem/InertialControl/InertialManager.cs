using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.MoveControlSys.InertialSys {
    /// <summary>
    /// 現在働いている慣性を管理するクラス
    /// </summary>
    public class InertialManager : MonoBehaviour {
        /// <summary>
        /// 現在働いている慣性のリスト
        /// </summary>
        public List<A_Inertial> inertials = new List<A_Inertial>();

        private void Start() {

        }

        private void Update() {
            ReleaseNotEnableInertial();
        }

        /// <summary>
        /// 有効化されていない慣性をリストから除外するメソッド
        /// </summary>
        private void ReleaseNotEnableInertial () {
            for (int i = 0; i < inertials.Count; i++) {
                if (!inertials[i].enable) {
                    inertials.RemoveAt(i);
                }
            }
        }
    }
}