
using UnityEngine;
using System.Collections;

namespace FrispAds.AdUnits {

	using ADBannerView = FrispAds.Api.ADBannerView;

	public class AppleAd : AdUnit {
		
		private ADBannerView banner;
		private bool showAd = true;
		private bool loaded = false;
		
		public AppleAd() {
			banner = ADBannerView.instance ();
			banner.CreateBanner ();
			banner.BannerViewDidLoadAd += BannerViewDidLoadAd;
			banner.DidFailToReceiveAdWithError += DidFailToReceiveAdWithError;
		}

		public void Hide() {
			showAd = false;
			banner.Hide ();
		}
		
		public void Show() {
			showAd = true;
			banner.Show ();
		}
		
		public bool Loaded() {
			return banner.Loaded ();
		}

		public void BannerViewDidLoadAd() {
			loaded = true;
			if (showAd) {
				Show ();
			}
		}

		public void DidFailToReceiveAdWithError() {
			loaded = false;
		}
	}
}
