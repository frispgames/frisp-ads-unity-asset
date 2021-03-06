#import <Foundation/Foundation.h>
#import <iAd/iAd.h>

@interface AppleAd : NSObject<ADBannerViewDelegate>

@property (strong)  ADBannerView *banner;

- (void) SetupBanner;
- (void) CreateBanner;
- (void) ShowAd;
- (void) HideAd;
- (void) resetContentSize:(UIInterfaceOrientation) orientation;
- (BOOL) AdLoaded;

@end
