using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace GenerallySys.Utility {
    /// <summary>
    /// 汎用的なメソッドをまとめたクラス using staicして使おう！
    /// </summary>
    public static class GenerallyUtility {
        /// <summary>
        /// 指定した型を継承したコンポーネントをリスト化して返すメソッド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> GetComponentsOfType<T>(GameObject obj) where T : Component {
            List<T> components = new List<T>();
            MonoBehaviour[] allObjects = obj.GetComponents<MonoBehaviour>();

            foreach (var com in allObjects) {
                if (com is T t) {
                    components.Add(t);
                }
            }

            return components;
        }
        /// <summary>
        /// 特定のUnityEventの発火が時間内にあればtrueを返して、そうでなければfalseを返すタスク
        /// </summary>
        /// <param name="unityEvent"></param>
        /// <param name="timeout"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        async public static UniTask<Boolean> WaitForUnityEvent (UnityEvent unityEvent,float timeout,CancellationToken token) {
            try{
                var tcs = new UniTaskCompletionSource();
                unityEvent.AddListener(OnTrigger);

                var completedTask = await UniTask.WhenAny(tcs.Task,UniTask.Delay(TimeSpan.FromSeconds(timeout),token.IsCancellationRequested));

                if (completedTask == 0){
                    return true;
                }
                else{
                    return false;
                }

                void OnTrigger () {
                    tcs.TrySetResult();
                    unityEvent.RemoveListener(OnTrigger);
                }
            }
            catch (OperationCanceledException) {
                return false;
            }
            finally{

            }
        }
    }
}