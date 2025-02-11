using Cysharp.Threading.Tasks;
using GenerallySys.Definition;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using static GenerallySys.Definition.CollectionValueType;

namespace GenerallySys.CollectionManageSys.Test {
	public class NormalCollection : A_Collection {

		private float timer = 0.0f;

		private CancellationTokenSource cts = new CancellationTokenSource();

		public NormalCollection(CollectionValueType type,float value,float duration) {
			this.type = type;
			this.collection = value;
			this.timer = duration;

			CancellationToken token = cts.Token;

		}

		async UniTaskVoid UpdationThread (CancellationToken token,UnityEvent endEvent,float duration) {
			try {
				var timerTask = CollectionDurationTimer(token, duration);
			}
			catch (OperationCanceledException) {

			}
			finally {

			}
		}

		/// <summary>
		/// 補正値が消滅するまでの時間をカウントするタイマー
		/// </summary>
		/// <param name="token"></param>
		/// <param name="duration"></param>
		/// <returns></returns>
		private async UniTaskVoid CollectionDurationTimer (CancellationToken token,float duration,float waitTime = 0.001f) {
			try {
				Debug.Log("補正値のタイマー処理を開始します");
				while (!token.IsCancellationRequested || timer <= 0.0f) {
					await UniTask.Delay(TimeSpan.FromSeconds(waitTime));
					timer -= waitTime;
					if (timer <= 0.0f || token.IsCancellationRequested) {
						break; 
					}
				}
			}
			catch(OperationCanceledException) {

			}
			finally {

			}
		}
	}
}