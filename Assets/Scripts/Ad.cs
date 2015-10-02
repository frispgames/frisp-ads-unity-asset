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
		adController.ShowBanner ();
	}
}
