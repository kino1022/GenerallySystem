using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}