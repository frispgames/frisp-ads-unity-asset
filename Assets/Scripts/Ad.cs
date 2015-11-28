using UnityEngine;
using System.Collections;

using FrispAd = FrispGames.Ads.FrispAd;

public class Ad : MonoBehaviour {

	private FrispAd adController;

	// Use this for initialization
	void Start () {
		adController = new FrispAd();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		adController.ShowBanner ();
	}
}
