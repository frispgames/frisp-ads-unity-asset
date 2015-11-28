#import "AppleAdController.h"

@implementation AppleAdController

static AppleAdController *singletonInstance = nil;

AppleAd *ad = nil;

+ (AppleAdController *) instance {
  if (!singletonInstance) {
    singletonInstance = [[AppleAdController alloc] init];
  }
  return singletonInstance;
}

- (void) CreateBannerAd {
  ad = [[AppleAd alloc] init];
  [ad CreateBanner];
}

- (void) HideBannerAd {
  if(ad != nil) {
    [ad HideAd];
  } 
}

- (void) ShowBannerAd {
  if(ad != nil) {
    [ad ShowAd];
  }
}

- (BOOL) BannerAdLoaded {
  if(ad != nil) {
    return [ad AdLoaded];
  }
  return false;
}

@end

extern "C" {
  
  void _AppleAdCreateBannerAd() {
    [[AppleAdController instance] CreateBannerAd];
  }
  
  void _AppleAdShowAd() {
    [[AppleAdController instance] ShowBannerAd];
  }
  
  void _AppleAdHideAd() {
    [[AppleAdController instance] HideBannerAd];
  }
  
  bool _AppleAdLoaded() {
    return [[AppleAdController instance] BannerAdLoaded];
  }
}
