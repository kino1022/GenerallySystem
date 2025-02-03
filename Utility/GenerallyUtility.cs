using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}