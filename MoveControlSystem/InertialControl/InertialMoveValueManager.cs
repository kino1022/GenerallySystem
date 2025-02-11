using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace GenerallySys.MoveControlSys.InertialSys {
    public class InertialMoveValueManager : A_MoveValueManager {
        /// <summary>
        /// 慣性管理マネージャーコンポーネントの領域
        /// </summary>
        private InertialManager _inetialManager;
        /// <summary>
        /// 慣性補正値マネージャーコンポーネントの領域
        /// </summary>
        private InertialMoveCollectionManager _collectionManager;

        private void Start () {
            //慣性管理マネージャーの取得処理「
            _inetialManager = GetComponent<InertialManager>();
            if (_inetialManager == null){
                Debug.Log("慣性管理マネージャーの取得に失敗しました");
            }
            else{
                Debug.Log("慣性管理マネージャーの取得に成功しました。");
            }
            //慣性補正値管理マネージャーの取得処理
            _collectionManager = GetComponent<InertialMoveCollectionManager>();
            if (_collectionManager == null) {
                Debug.Log("慣性補正値管理マネージャーの取得に失敗しました。");
            }
            else {
                Debug.Log("慣性補正値管理マネージャーの取得に成功しました。");
            }
        }

        private void Update() {
            TotalMoveValue = CalculationTotalValue() * _collectionManager.totalValue;
        }
        
        /// <summary>
        ///　現在働いている慣性の総量を算出して返すメソッド
        /// </summary>
        /// <returns></returns>
        private Vector3 CalculationTotalValue () {
            var totalValue = Vector3.zero;
            foreach (A_Inertial inertial in _inetialManager.inertials){
                totalValue += inertial.totalMoveValue;
            }
            return totalValue;
        }
    }
}