using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.IO;
using System.Net;

namespace Asi.Itb.WcfRestService
{
    /// <summary>
    /// Interface of upload and download arbitrary stream data.
    /// </summary>
    [ServiceContract]
    public interface IUploadDownloadData
    {
        [OperationContract, WebInvoke(UriTemplate="Sync")]
        Stream Sync(Stream uploadData);
    }

    /// <summary>
    /// Represents a service which echos back received stream data to console, and returns sample response xml as response data.
    /// </summary>
    public class RawDataService : IUploadDownloadData
    {
        public Stream Sync(Stream uploadData)
        {
            System.IO.StreamReader rdr = new System.IO.StreamReader(uploadData);
            string request = rdr.ReadToEnd();
            rdr.Close();
            Console.WriteLine("Service: Received content: {0}", request);

            FileStream fs = new FileStream("ItbResponse.xml", FileMode.Open, FileAccess.Read);
            return fs;
        }
    }

    /// <summary>
    /// Represents a test program to emulate REST web service to be used by scanner client.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(RawDataService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IUploadDownloadData), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened. Press Enter to end...");
            Console.ReadLine();
            host.Close();
        }
    }
}