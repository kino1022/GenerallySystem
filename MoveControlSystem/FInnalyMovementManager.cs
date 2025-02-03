using GenerallySys.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GenerallySys.Utility.GenerallyUtility;

namespace GenerallySys.MoveControlSys {
    /// <summary>
    /// アタッチされているすべてのA_MoveValueManagerを取得して、その総移動量を算出するコンポーネント
    /// </summary>
    public class FinnalyMovementManager : MonoBehaviour {
        /// <summary>
        /// アタッチされているすべてのA_MoveValueManager
        /// </summary>
        [SerializeField]
        private List<A_MoveValueManager> _allManager = new List<A_MoveValueManager>();
        /// <summary>
        /// トータルの移動量
        /// </summary>
        [SerializeField]
        public float totalMovement = 0.0f;

        void Start() {
            _allManager = GenerallyUtility.GetComponentsOfType<A_MoveValueManager>(this.gameObject);
        }

        void Update() {
            
        }
    }
}