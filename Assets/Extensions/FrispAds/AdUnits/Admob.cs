using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

namespace FrispAds.AdUnits {
	public class Admob : MonoBehaviour, AdUnit {

		private BannerView banner;
		private bool loaded = false;
		private bool showBanner = false;
		private readonly Configuration config;

		public Admob() {
			config = Resources.Load<Configuration>("FrispAds/Configuration");
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
				return config.androidAdmobId;
			} else {
				print(config);
				return config.appleAdmobId;
			}
		}
	}
}
