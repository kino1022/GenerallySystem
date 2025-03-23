using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace GenerallySys.Utility {
    /// <summary>
    /// �ėp�I�ȃ��\�b�h���܂Ƃ߂��N���X using staic���Ďg�����I
    /// </summary>
    public static class GenerallyUtility {
        /// <summary>
        /// �w�肵���^���p�������R���|�[�l���g�����X�g�����ĕԂ����\�b�h
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
        /// �����UnityEvent�̔��΂����ԓ��ɂ����true��Ԃ��āA�����łȂ����false��Ԃ��^�X�N
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