using RestSharp;
using System.Net;

namespace VirtualMeetingMonitor
{
    internal class OnAirSign
    {
        private readonly string url = "http://onair.local";

        public bool TurnOn(int hue, int sat) => CallAPI($"{{ \"on\": true, \"hue\" : {hue}, \"sat\": {sat} }}") == HttpStatusCode.OK;

        public bool TurnOff() => CallAPI("{ \"on\": false }") == HttpStatusCode.OK;
        
        private HttpStatusCode CallAPI( string body )
        {
            RestClient client = new RestClient(url);
            const string api = "/api/userid/lights/1/state";
            var request = new RestRequest(api, Method.PUT);
            request.AddJsonBody(body);
            return client.Execute(request).StatusCode;
        }
    }
}