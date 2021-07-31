using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class ads : MonoBehaviour
{
    string Google = "ca-app-pub-1017086941685097~4801545519";
    string add1 = "	ca-app-pub-1017086941685097/8552555436";
    string add2 = "ca-app-pub-1017086941685097/1604003701";
    private InterstitialAd interstitial;
    private InterstitialAd interstitial1;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        requestAd();
    }

  

    public void requestAd()
    {
        this.interstitial = new InterstitialAd(add1);
        this.interstitial1 = new InterstitialAd(add2);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        this.interstitial1.LoadAd(request);
    }

    public void showAd()
    {
        if(this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
       else if(this.interstitial1.IsLoaded())
        {
            this.interstitial1.Show();
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
