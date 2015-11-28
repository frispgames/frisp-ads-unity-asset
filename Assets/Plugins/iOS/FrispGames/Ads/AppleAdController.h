#import <Foundation/Foundation.h>
#import <iAd/iAd.h>

#include "AppleAd.h"

@interface AppleAdController : NSObject {}

+ (AppleAdController *) instance;

- (void) CreateBannerAd;
- (void) HideBannerAd;
- (void) ShowBannerAd;

@end