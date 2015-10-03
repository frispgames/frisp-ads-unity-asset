# Frisp Ads
Unity asset for handling iPhone ads - Currently only supports landscape orientation.

### Development

I have set the repository up as a unity project. When adding features you will need to open the contents of the repository in unity.

### Installing into your own project

* Download the [asset](https://github.com/frispgames/frisp-ads-unity-asset/blob/master/package/frisp-ads.unitypackage) and import it into your unity project.
* Download the [google ads asset](https://github.com/googleads/googleads-mobile-unity/releases) and import it into your unity project
* Create a class like below and attach it to an empty game object:
```CSHARP
using UnityEngine;
using System.Collections;

public class Ad : MonoBehaviour {

	private FrispAds.FrispAd adController;

	// Use this for initialization
	void Start () {
		adController = new FrispAds.FrispAd();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	  // Logic around how you want to show and hide your banner
		adController.ShowBanner ();
	}
}
```
* Add your Admob id's into the configuration asset which can be found under ``Resources/FrispAds/Configuration`` all you need to do is click on the asset and fill out the fields in the sidebar.

