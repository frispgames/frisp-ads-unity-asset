using UnityEngine;
using System.Collections;
namespace FrispAds {

	using AdUnit  = FrispAds.AdUnits.AdUnit;
	using Admob   = FrispAds.AdUnits.Admob;
	using AppleAd = FrispAds.AdUnits.AppleAd;

	public class FrispAd {
		#if UNITY_IPHONE || UNITY_EDITOR
		private static AdUnit iAdBanner = null;
		#endif

		private static AdUnit adMobBanner = null;

		public FrispAd() {
			#if UNITY_IPHONE
			if (iAdBanner == null && Application.platform == RuntimePlatform.IPhonePlayer) {
				iAdBanner = new AppleAd ();
			}
			#endif
			#if UNITY_IPHONE || UNITY_ANDROID
			if (adMobBanner == null) {
				adMobBanner = new Admob ();
			}
			#endif
		}
		
		// Prioritize iAd over adMob as iAd pays more
		public void ShowBanner () {
			#if UNITY_IPHONE
			if (iAdBanner.Loaded ()) {
				adMobBanner.Hide ();
				iAdBanner.Show ();
			} else {
				adMobBanner.Show ();
				iAdBanner.Hide ();
			}
			#endif

			#if UNITY_ANDROID
			adMobBanner.Show ();
			#endif
		}

		public void HideBanner () {
			#if UNITY_IPHONE || UNITY_ANDROID
			adMobBanner.Hide ();
			#endif
			#if UNITY_IPHONE
			iAdBanner.Hide ();
			#endif
		}
	}
}
