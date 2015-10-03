using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;

public class FrispAdsPostProcessor {

	const string GOOGLE_ADS_ID = "C04DE2DB1BBEA0CD00D1722D";
	const string GOOGLE_ADS_FILEREFID = "C04DE2DA1BBEA0CD00D1722D";

	[PostProcessBuild(1500)]
	public static void OnPostProcessBuild(BuildTarget target, string path) {
		#if UNITY_IPHONE
		if (target != BuildTarget.iOS) return;

		UnityEngine.Debug.Log("PostProcessor: Copying frameworks to xcode");

		string srcName = "AppleFrameworks";
		string buildName = Path.GetFileNameWithoutExtension(path);
		string pbxprojPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

		PBXProject proj = new PBXProject();
		
		proj.ReadFromString(File.ReadAllText(pbxprojPath));

		String buildTarget = proj.TargetGuidByName("Unity-iPhone");

		DirectoryInfo projectParent = Directory.GetParent(Application.dataPath);

		char divider = Path.DirectorySeparatorChar;

		DirectoryInfo sourceFolder = new DirectoryInfo(projectParent.ToString() + divider + "Assets" + divider + srcName);
		DirectoryInfo destinationFolder = new DirectoryInfo(path + divider + "Frameworks");

		// Copy Frameworks to 
		CopyAll(sourceFolder, destinationFolder);
	
		foreach(DirectoryInfo file in destinationFolder.GetDirectories()) {
			UnityEngine.Debug.Log("PostProcessor: Adding file to build - " + file.Name);
			proj.AddFile("Frameworks/"+ file.Name, "Frameworks/"+ file.Name, PBXSourceTree.Source);
			proj.AddFrameworkToProject (buildTarget, file.Name, false);
		}

		proj.SetBuildProperty(buildTarget, "FRAMEWORK_SEARCH_PATHS", "$(SRCROOT)/Frameworks");
		proj.AddBuildProperty(buildTarget, "FRAMEWORK_SEARCH_PATHS", "$(inherited)");
		proj.SetBuildProperty(buildTarget, "CLANG_ENABLE_MODULES", "YES");

		File.WriteAllText(pbxprojPath, proj.WriteToString());
		#endif
	}


	public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
		// Check if the target directory exists, if not, create it.
		if (Directory.Exists(target.FullName) == false)
		{
			Directory.CreateDirectory(target.FullName);
		}
		
		// Copy each file into it’s new directory.
		foreach (FileInfo fi in source.GetFiles())
		{
			fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
		}
		
		// Copy each subdirectory using recursion.
		foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		{
			DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
			CopyAll(diSourceSubDir, nextTargetSubDir);
		}
	}
	
}