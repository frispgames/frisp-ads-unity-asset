using UnityEngine;
using System.Collections;
namespace FrispAds {

	using AdUnit = FrispAds.AdUnits.AdUnit;
	using Admob = FrispAds.AdUnits.Admob;
	using AppleAd = FrispAds.AdUnits.AppleAd;
	using FakeAdUnit = FrispAds.AdUnits.AppleAd;

	public class FrispAd {

		private static AdUnit iAdBanner = new FakeAdUnit();
		private static AdUnit adMobBanner = new FakeAdUnit();

		public FrispAd() {
			if (iAdBanner == null && isAppleDevice()) {
				iAdBanner = AppleAd();
			}
			if (adMobBanner == null && isAppleDevice() || isAndroidDevice()) {
				adMobBanner = Admob();
			}
		}
		
		// Prioritize iAd over adMob as iAd pays more
		public void ShowBanner () {
			if (iAdBanner.Loaded ()) {
				adMobBanner.Hide ();
				iAdBanner.Show ();
			} else {
				adMobBanner.Show ();
				iAdBanner.Hide ();
			}
		}

		public void HideBanner () {
			adMobBanner.Hide ();
			iAdBanner.Hide ();
		}

		private bool isAndroidDevice() {
			return Application.platform == RuntimePlatform.Android;
		}

		private bool isAppleDevice() {
			return Application.platform == RuntimePlatform.IPhonePlayer;
		}
	}
}
