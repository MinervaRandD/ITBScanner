using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Asi.Itb.Dal
{
    /// <summary>
    /// Represents web service client to send and receive data from server 
    /// </summary>
    public class WebServiceClient
    {
        /// <summary>
        /// Connect to server to send up load request data, and get response stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Stream GetStreamFromLegacyPostRequest(string request, string uri)
        {
#if Local
            return this.GetTestResponseStream();
#endif
            string rawRequest = "payload=" + request;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "POST";
            req.ContentLength = rawRequest.Length;
            req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            Stream reqStream = req.GetRequestStream();
            StreamWriter sw = new StreamWriter(reqStream);
            sw.Write(rawRequest);
            sw.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();
            return respStream;
        }

        /// <summary>
        /// Connect to server to send up load request data, and get response stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Stream GetStreamFromUpdatedPostRequest(string request, string uri)
        {
#if Local
            return this.GetTestResponseStream();
#endif
            Stream respStream = null;
            HttpWebRequest req = null;

            try
            {
                req = (HttpWebRequest)HttpWebRequest.Create(uri);
                req.Method = "POST";
                req.Credentials = null;

                req.ContentType = "application/json";
                req.ContentLength = request.Length;
                req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Stream reqStream = req.GetRequestStream();
                StreamWriter sw = new StreamWriter(reqStream);
                sw.Write(request.ToCharArray(), 0, request.Length);
                sw.Close();

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                respStream = resp.GetResponseStream();
            }

            catch (Exception ex)
            {
                string msg = ex.Message;

                SyncLogManager.logSyncError("GetStreamFromLegacyPostRequest", "Sync error has occured", ex);
               
                //MessageBox.Show("GetStreamFromUpdatedPostRequest exception: " + ex.Message + "\n" + ex.StackTrace);

                return null;
            }

            return respStream;
        }
        /// <summary>
        /// Connect to server to send up local request data, and retrieve response data in xml.
        /// </summary>
        /// <param name="request">Request xml string</param>
        /// <param name="uri">URI to send request to</param>
        /// <returns>Response xml string</returns>
        public string GetXmlFromPostRequest(string request, string uri)
        {
            Stream respStream = this.GetStreamFromLegacyPostRequest(request, uri);
            StreamReader sr = new StreamReader(respStream);
            string ret = sr.ReadToEnd();
            sr.Close();

            return ret;
        }

        /// <summary>
        /// Test utility method, returning stream to sample response xml.
        /// </summary>
        /// <returns></returns>
        private Stream GetTestResponseStream()
        {
            #region sample xml response
            string responseXml = @"
<ItbResponse>
  <ServerTime>2009-09-01 12:25:01.435243</ServerTime>
  <ProgramUpgradeFiles>
    <File>
      <Name>ITB.1.1.3.cab</Name>
      <Size>9872347</Size>
    </File>
    <File>
      <Name>ITB.Bll.1.1.3.cab</Name>
      <Size>438347</Size>
    </File>
  </ProgramUpgradeFiles>
  <ConfigUpgradeFiles>
    <File>
      <Name>Config.LAX2.cab</Name>
      <Size>348946</Size>
    </File>
  </ConfigUpgradeFiles>
  <ExitCode>1342ade123c498bc12</ExitCode>
  <GpsUploadIntervalSeconds>60</GpsUploadIntervalSeconds>
  <BagDropOffTimeLimitMinutes>10</BagDropOffTimeLimitMinutes>
  <Users>
    <User>
      <UserName>twink</UserName>
      <Password>254a3657bc45de23f</Password>
      <Salt>m9DPOYd24b7TQmdq6DBo</Salt>
      <Level>Transport</Level>
    </User>
    <User>
      <UserName>mavis</UserName>
      <Password>9548b657bc45de290</Password>
      <Salt>n8TPOYd24PiTR7dq6DBy</Salt>
      <Level>Transport</Level>
    </User>
    <User>
        <UserName>henrytest</UserName>
        <Password>d40215d965021fdfe2f7fd4946c5c0fb7fedafdc</Password>
        <Level>supervisor</Level>
        <Salt>FxmgCcVxTK2kJ0ljE9t4</Salt>
    </User>
  </Users>
  <Locations>
    <Location>
      <Name>ABC23434</Name>
      <Type>P</Type>
      <Gps>33.72434,-118.476562</Gps>
      <Carriers>CO,UA</Carriers>
    </Location>
    <Location>
      <Name>CDE2343</Name>
      <Type>D</Type>
      <Gps>33.72438,-118.476589</Gps>
      <Carriers>AA,US,DL</Carriers>
    </Location>
    <Location>
      <Name>CAGE1_IN</Name>
      <Type>I</Type>
      <Gps>38.72438,-148.476589</Gps>
      <Carriers>AA,US,DL</Carriers>
    </Location>
    <Location>
      <Name>CAGE1_OUT</Name>
      <Type>O</Type>
      <Gps>38.72438,-148.476589</Gps>
      <Carriers>AA,US,DL</Carriers>
    </Location>
  </Locations>
  <Flights>
    <Flight>
      <Carrier>CO</Carrier>
      <Number>77</Number>
      <ArrivalTime>09:34</ArrivalTime>
    </Flight>
    <Flight>
      <Carrier>UA</Carrier>
      <Number>485</Number>
      <DepartureTime>14:25</DepartureTime>
    </Flight>
    <Flight>
      <Carrier>CO</Carrier>
      <Number>123</Number>
      <ArrivalTime>10:09</ArrivalTime>
    </Flight>
    <Flight>
      <Carrier>US</Carrier>
      <Number>59</Number>
      <ArrivalTime>11:00</ArrivalTime>
      <DepartureTime>12:30</DepartureTime>
    </Flight>
  </Flights>
  <Bsm>
    <Bag>
      <Barcode>3205175431</Barcode>
      <DestLocation>CDE2324</DestLocation>
      <InboundCarrier>CO</InboundCarrier>
      <InboundFlight>77</InboundFlight>
      <OutboundCarrier>UA</OutboundCarrier>
      <OutboundFlight>485</OutboundFlight>
    </Bag>
    <Bag>
      <Barcode>3205175432</Barcode>
      <DestLocation>ABC1234</DestLocation>
      <InboundCarrier>CO</InboundCarrier>
      <InboundFlight>123</InboundFlight>
      <OutboundCarrier>US</OutboundCarrier>
      <OutboundFlight>59</OutboundFlight>
    </Bag>
  </Bsm>
  <Scans>
    <Scan>
      <Barcode>3205175433</Barcode>
      <Operation>1</Operation>
      <Location>ABCD123</Location>
      <ScanTime>2009-09-01 18:55:35.55215</ScanTime>
    </Scan>
    <Scan>
      <Barcode>3205175432</Barcode>
      <Operation>2</Operation>
      <Location>XYZ1234</Location>
      <ScanTime>2009-09-01 19:10:01.6528</ScanTime>
    </Scan>
  </Scans>
  <Messages>
    <Message>
      <Subject>Flight CO123 is delayed</Subject>
      <Content>By 1 minute.</Content>
      <MessageTime>2009-09-01 09:10:34.32323</MessageTime>
    </Message>
    <Message>
      <Subject>Flight UA124 is canceled.</Subject>
      <Content>Due to weather condition at SFO.</Content>
      <MessageTime>2009-09-01 11:12:14.98798</MessageTime>
    </Message>
  </Messages>
</ItbResponse>
";
            #endregion
            Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(responseXml));
            return s;
        }
    }
}
