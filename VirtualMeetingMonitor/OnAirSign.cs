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
        };

        public OnAirSign()
        {

        }


        public bool TurnOn(byte red, byte green, byte blue)
        {
            var retVal = false;
            var body = new LightRGB(red, green, blue);
            if (CallAPI(body) == HttpStatusCode.OK)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool TurnOff()
        {
            var retVal = false;
            var body = new LightRGB( 0, 0, 0);
            if ( CallAPI(body) == HttpStatusCode.OK )
            {
                retVal = true;
            }
            return retVal;
        }

        private HttpStatusCode CallAPI( LightRGB body )
        {
            HttpStatusCode statusCode = 0;
            var client = new RestClient(url);
            var api = "/api/light/state";
            var request = new RestRequest(api, Method.POST);
            request.AddJsonBody(body);
            var result = client.Execute(request);
            statusCode = result.StatusCode;
            return statusCode;
        }

    }

}