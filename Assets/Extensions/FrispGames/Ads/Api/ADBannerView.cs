using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace FrispGames.Ads.Api {
	public class ADBannerView : MonoBehaviour {

		[DllImport ("__Internal")]
		private static extern void _AppleAdCreateBannerAd ();

		[DllImport ("__Internal")]
		private static extern void _AppleAdShowAd ();

		[DllImport ("__Internal")]
		private static extern void _AppleAdHideAd ();

		[DllImport ("__Internal")]
		private static extern bool _AppleAdLoaded ();

		private static ADBannerView _instance;

		public Action BannerViewDidLoadAd  			= delegate {};
		public Action DidFailToReceiveAdWithError  	= delegate {};
		public Action BannerViewActionShouldBegin  	= delegate {};
		public Action BannerViewActionDidFinish 	= delegate {};
		public Action BannerViewWillLoadAd          = delegate {};

		public static ADBannerView instance() {
			if (_instance == null) {
					_instance = GameObject.FindObjectOfType(typeof(ADBannerView)) as ADBannerView;
				if (_instance == null) {
					_instance = new GameObject ("ADBannerView").AddComponent<ADBannerView> ();
					DontDestroyOnLoad (_instance);
				}
			}
			return _instance;
		}

		public void Hide() {
			_AppleAdHideAd ();
		}

		public void CreateBanner() {
			_AppleAdCreateBannerAd ();
		}
		
		public void Show() {
			_AppleAdShowAd ();
		}

		public bool Loaded() {
			return _AppleAdLoaded ();
		}

		public void bannerViewActionShouldBegin () {
			BannerViewActionShouldBegin ();
		}

		public void bannerViewActionDidFinish () {
			BannerViewActionDidFinish ();
		}

		public void bannerViewDidLoadAd () {
			BannerViewDidLoadAd ();
		}

		public void bannerViewWillLoadAd () {
			BannerViewWillLoadAd ();
		}

		public void didFailToReceiveAdWithError () {
			DidFailToReceiveAdWithError ();
		}
	}
}