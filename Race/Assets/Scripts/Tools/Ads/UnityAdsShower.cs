using System;
using UnityEngine;
using UnityEngine.Advertisements;


namespace Tools.Ads
{
    internal class UnityAdsShower : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private const string _gameId = "4159155";
        private const string _interstitialPlace = "Interstitial_Android";

        private Action _callbackSuccessShowVideo;


        private void Awake()
        {
            Advertisement.Initialize(_gameId, true);
        }

        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(_interstitialPlace);
        }


        public void OnUnityAdsReady(string placementId)
        {

        }

        public void OnUnityAdsDidError(string message)
        {

        }

        public void OnUnityAdsDidStart(string placementId)
        {

        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
                _callbackSuccessShowVideo?.Invoke();
        }
    }
}

