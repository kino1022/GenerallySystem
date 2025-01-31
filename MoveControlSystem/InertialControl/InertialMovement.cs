using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;


namespace GenerallySys.MoveControlSys.InertialSys {
    /// <summary>
    /// 慣性の一定時間ごとに減少する運動量を表現するためのクラス。インスタンス化した際にA_Inertialの参照を要求。
    /// </summary>
    public class InertialMovement {

        private float movement = 0.0f;
        /// <summary>
        /// 算出された移動量。代入される度に紐付けられた慣性クラスに対して代入処理をする。
        /// </summary>
        public float Movement {
            get { return movement; }
            set { 
                movement = value;
                inertial.movement = movement;
            }
        }

        /// <summary>
        /// 紐づける慣性クラス。
        /// </summary>
        private A_Inertial inertial;
        /// <summary>
        /// 慣性の減衰量（0.0秒毎に減衰処理がなされるのを前提として設定する事。）
        /// </summary>
        private float dumpingValue = 0.0f;
        /// <summary>
        /// 慣性の減衰処理を行う間隔。
        /// </summary>
        private float interval = 0.01f;
        /// <summary>
        /// Movementがこの値を下回った場合に慣性の減衰処理を停止する閾値。
        /// </summary>
        private float destractionValue = 0.002f;

        private CancellationTokenSource cts = new CancellationTokenSource();

        public InertialMovement(A_Inertial setInertial,float setMovement,float setDumping) {
            inertial = setInertial;
            Movement = setMovement;
            dumpingValue = setDumping;

            CancellationToken token = cts.Token;
            DecreaseMovement(cts.Token).Forget();
        }

        private async UniTaskVoid DecreaseMovement (CancellationToken token) {
            try {
                Debug.Log("慣性運動量の減衰処理を開始します");
                while (!token.IsCancellationRequested || movement < destractionValue) {
                    await UniTask.Delay(TimeSpan.FromSeconds(interval));
                    Movement *= dumpingValue;
                    if (Movement < destractionValue) {
                        Debug.Log("慣性運動量の値が閾値を下回ったため、減衰ループを終了します");
                        break;
                    }
                    else if (token.IsCancellationRequested) {
                        Debug.Log("キャンセルがスローされた為、減衰ループを終了します。");
                    }
                }
                Debug.Log("慣性の減衰ループを終了しました。");
            }
            catch (OperationCanceledException) {

            }
            finally {
                inertial.enable = false;
            }
        }
    }
}