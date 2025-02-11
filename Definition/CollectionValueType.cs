using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerallySys.Definition {
	/// <summary>
	/// 補正値の値の種類が整数値か割合かを示すEnum
	/// </summary>
	public enum CollectionValueType {
		/// <summary>
		/// 割合での補正値
		/// </summary>
		Ratio = 0,
		/// <summary>
		/// 固定値での補正値
		/// </summary>
		Fixed = 1,
	}
}