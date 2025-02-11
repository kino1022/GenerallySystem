using GenerallySys.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GenerallySys.Utility.GenerallyUtility;

namespace GenerallySys.MoveControlSys {
    /// <summary>
    /// アタッチされているすべてのA_MoveValueManagerを取得して、その総移動量を算出するコンポーネント
    /// </summary>
    public class FinalyMovementManager : MonoBehaviour {
        /// <summary>
        /// アタッチされているすべてのA_MoveValueManager
        /// </summary>
        [SerializeField]
        private List<A_MoveValueManager> _allManager = new List<A_MoveValueManager>();
        /// <summary>
        /// トータルの移動量
        /// </summary>
        [SerializeField]
        public Vector3 totalMovement = Vector3.zero;

        void Start() {
            _allManager = GenerallyUtility.GetComponentsOfType<A_MoveValueManager>(this.gameObject);
        }

        void Update() {
            totalMovement = GetTotalMoveValue();
        }
        /// <summary>
        /// _allManagerに格納されている全てのTotalMoveValueを合計した値を返却するメソッド
        /// </summary>
        /// <returns></returns>
        private Vector3 GetTotalMoveValue () {
            var totalValue = Vector3.zero;
            foreach (var value in _allManager) {
                totalValue += value.TotalMoveValue;
            }
            return totalValue;
        }
    }
}