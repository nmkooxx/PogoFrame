//
//  JoyingMobiVideoAd_C.m
//  VideoSample
//
//  Created by Ethan.W on 16/7/11.
//  Copyright © 2016年 HuaiNan. All rights reserved.
//

#import "JoyingMobiVideoAd.h"

@interface JoyingMobiVideoAd_C : NSObject

@end

@implementation JoyingMobiVideoAd_C

- (id)init
{
    id object = [super init];
    
    NSLog(@"JoyingMobiVideoAd_C init");
    
    return object;
}

@end

JoyingMobiVideoAd_C *m_JoyingMobiVideo_C = NULL;

extern "C"
{
    
    void init () {
        if (m_JoyingMobiVideo_C == NULL) {
            m_JoyingMobiVideo_C = [[JoyingMobiVideoAd_C alloc] init];
        }
        
        NSLog(@"NSLog: init");
    }
    
    void initAppID (char* appId, char* appKey) {
        NSLog(@"NSLog: initAppID");
        NSString* appId_str = [NSString stringWithUTF8String:appId];
        NSString* appKey_str = [NSString stringWithUTF8String:appKey];
        
        NSLog(@"appId: %@", appId_str);
        NSLog(@"initAppID: %@", appKey_str);
        [JoyingMobiVideoAd initAppID:appId_str appKey:appKey_str];
    }
    
}

