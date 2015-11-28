using UnityEngine;
using System.Collections;
namespace FrispGames.Ads {

	using AdUnit = AdUnits.AdUnit;
	using Admob = AdUnits.Admob;
	using AppleAd = AdUnits.AppleAd;
	using FakeAdUnit = AdUnits.FakeAdUnit;

	public class FrispAd : MonoBehaviour {

		private static AdUnit iAdBanner = null;
		private static AdUnit adMobBanner = null;

		public FrispAd() {
			if (iAdBanner == null) iAdBanner = iAdUnit();
			if (adMobBanner == null) adMobBanner = admobAdUnit();
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

		private AdUnit iAdUnit() {
			if (isAppleDevice ()) {
				return new AppleAd ();
			} else {
				return new FakeAdUnit ();
			}
		}

		private AdUnit admobAdUnit() {
			if (isAppleDevice () || isAndroidDevice()) {
				return new Admob ();
			} else {
				return new FakeAdUnit ();
			}
		}

		private bool isAndroidDevice() {
			#if UNITY_ANDROID && !UNITY_EDITOR
				return true;
			#else
				return false;
			#endif
		}

		private bool isAppleDevice() {
			#if UNITY_IPHONE && !UNITY_EDITOR
				return true;
			#else
				return false;
			#endif
		}
	}
}
