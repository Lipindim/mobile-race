using System.Collections.Generic;
using UnityEngine.Analytics;


namespace Tools.Analytic
{
    internal class UnityAnalyticTools : IAnalyticTools
    {
        public void SendMessage(string eventName)
        {
            var eventData = new Dictionary<string, object>();
            Analytics.CustomEvent(eventName, eventData);
        }
    }
}
