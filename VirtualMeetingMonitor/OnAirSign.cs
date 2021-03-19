using RestSharp;
using System.Net;

namespace VirtualMeetingMonitor
{
    internal class OnAirSign
    {
        private readonly string url = "http://onair.local";

        class LightRGB
        {
            public LightRGB( byte red, byte green, byte blue )
            {
                Red = red;
                Green = green;
                Blue = blue;
            }
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }
        }

        public bool TurnOn(byte red, byte green, byte blue) => CallAPI(new LightRGB(red, green, blue)) == HttpStatusCode.OK;

        public bool TurnOff() => CallAPI(new LightRGB(0, 0, 0)) == HttpStatusCode.OK;
        
        private HttpStatusCode CallAPI( LightRGB body )
        {
            RestClient client = new RestClient(url);
            const string api = "/api/light/state";
            var request = new RestRequest(api, Method.POST);
            request.AddJsonBody(body);
            return client.Execute(request).StatusCode;
        }
    }
}