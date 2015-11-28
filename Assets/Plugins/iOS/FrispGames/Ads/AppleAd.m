#import "AppleAd.h"

@implementation AppleAd

- (void) SetupBanner {
  [self setBanner: [[ADBannerView alloc] initWithFrame:CGRectZero]];
  [[self banner] setAutoresizingMask:UIViewAutoresizingFlexibleWidth];
  [self banner].delegate = self;
  [[self banner] setBackgroundColor:[UIColor clearColor]];
}

- (void) CreateBanner {
  [self SetupBanner];
  
  UIViewController *rootViewController =  [[[[UIApplication sharedApplication]delegate] window] rootViewController];
  
  NSSet *contentSizeSet = [NSSet setWithObjects:ADBannerContentSizeIdentifierLandscape,ADBannerContentSizeIdentifierPortrait, nil];

  [[self banner] setRequiredContentSizeIdentifiers: contentSizeSet];

  [self resetContentSize: rootViewController.interfaceOrientation];
  
  [self banner].frame = CGRectMake(0,
                                   rootViewController.view.frame.size.height - _banner.frame.size.height,
                                   [self banner].frame.size.width,
                                   [self banner].frame.size.height);
  
  [[rootViewController view] addSubview: [self banner]];
  
  [self banner].hidden = true;
}

- (void) HideAd {
  [self banner].hidden = true;
}

- (void) ShowAd {
  [self banner].hidden = false;
}

- (BOOL) AdLoaded {
  return [self banner].bannerLoaded;
}

-(void)bannerView:(ADBannerView *)banner didFailToReceiveAdWithError:(NSError *)error {
  if(error != nil) {
       NSLog(@"didFailToReceiveAdWithError %@", error.description);
  }
  
  UnitySendMessage("ADBannerView", "didFailToReceiveAdWithError", "");
}

- (void) bannerViewDidLoadAd:(ADBannerView *)banner {
  NSLog(@"bannerViewDidLoadAd");
  UnitySendMessage("ADBannerView", "bannerViewDidLoadAd", "");
}

- (void) bannerViewWillLoadAd:(ADBannerView *)banner {
  NSLog(@"bannerViewWillLoadAd");  
  UnitySendMessage("ADBannerView", "bannerViewWillLoadAd", "");
}

- (void) bannerViewActionDidFinish:(ADBannerView *)banner {
  NSLog(@"bannerViewActionDidFinish");
  UnitySendMessage("ADBannerView", "bannerViewActionDidFinish", "");
}

- (BOOL) bannerViewActionShouldBegin:(ADBannerView *)banner willLeaveApplication:(BOOL)willLeave {
  NSLog(@"bannerViewActionShouldBegin");
  UnitySendMessage("ADBannerView", "bannerViewActionShouldBegin", "");
  return true;
}

@end
