using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

namespace FrispAds.AdUnits {
	public class Admob : AdUnit {

		private BannerView banner = null;
		private bool loaded = false;
		private bool showBanner = false;

		public Admob() {
			banner = new BannerView (AdMobID (), AdSize.SmartBanner, AdPosition.Bottom);
			banner.AdLoaded += OnBannerLoaded;
			RequestBanner ();
		}

		public void Hide() {
			banner.Hide ();
			showBanner = false;
		}
		
		public void Show() {
			banner.Show ();
			showBanner = true;
		}

		public bool Loaded() {
			return loaded;
		}

		private void RequestBanner() {
			AdRequest request = new AdRequest.Builder().Build();
			banner.LoadAd(request);
		}

		private void OnBannerLoaded(object sender, EventArgs args) {
			loaded = true;
			if (showBanner) {
				Show ();
			}
		}

		private string AdMobID() {
			if (Application.platform == RuntimePlatform.Android) {
				return "ca-app-pub-1577026775528950/8069642828";
			} else {
				return "ca-app-pub-1577026775528950/3639443229";
			}
		}
	}
}
