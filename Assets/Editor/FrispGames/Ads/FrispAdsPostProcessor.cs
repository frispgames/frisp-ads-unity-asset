using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;

public class FrispAdsPostProcessor {

	[PostProcessBuild(1500)]
	public static void OnPostProcessBuild(BuildTarget target, string path) {
		#if UNITY_IPHONE
			if (target != BuildTarget.iOS) return;

			string buildName = Path.GetFileNameWithoutExtension(path);
			string pbxprojPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject proj = new PBXProject();
			
			proj.ReadFromString(File.ReadAllText(pbxprojPath));

			string buildTarget = proj.TargetGuidByName("Unity-iPhone");

			DirectoryInfo projectParent = Directory.GetParent(Application.dataPath);

			char divider = Path.DirectorySeparatorChar;

			DirectoryInfo destinationFolder =
				new DirectoryInfo(path + divider + "Frameworks");
		
			foreach(DirectoryInfo file in destinationFolder.GetDirectories()) {
				string filePath = "Frameworks/"+ file.Name;
				proj.AddFile(filePath, filePath, PBXSourceTree.Source);
				proj.AddFrameworkToProject (buildTarget, file.Name, false);
			}

			proj.SetBuildProperty(
				buildTarget, "FRAMEWORK_SEARCH_PATHS", "$(SRCROOT)/Frameworks"
			);
			proj.AddBuildProperty(
				buildTarget, "FRAMEWORK_SEARCH_PATHS", "$(inherited)"
			);
			proj.SetBuildProperty(buildTarget, "CLANG_ENABLE_MODULES", "YES");

			File.WriteAllText(pbxprojPath, proj.WriteToString());
		#endif
	}
}