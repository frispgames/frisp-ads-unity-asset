using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FrispAds {
	public class Configuration : ScriptableObject {
		
		public string appleAdmobId;
		public string androidAdmobId;
		#if UNITY_EDITOR
		[MenuItem("Assets/Create/Configuration")]
		public static void Create() {
			string assetPathAndName =
				AssetDatabase.GenerateUniqueAssetPath("Assets/Extensions/FrispAds/Configuration.asset");
			
			var asset = CreateInstance<Configuration>();
			AssetDatabase.CreateAsset(asset, assetPathAndName);
			
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
	#endif
	}
}