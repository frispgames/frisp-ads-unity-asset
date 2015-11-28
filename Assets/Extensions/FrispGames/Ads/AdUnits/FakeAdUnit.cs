﻿using UnityEngine;
using System.Collections;

namespace FrispGames.Ads.AdUnits {
	public class FakeAdUnit : MonoBehaviour, AdUnit {
		public void Hide() {
			print ("Called Hide for Fake Ad");
		}

		public void Show() {
			print ("Called Show for Fake Ad");
		}

		public bool Loaded() {
			return false;
		}
	}
}
