using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RestSharp;

namespace SignalRTest.WCF
{
    public class SignalRTestService : ISignalRTestService
    {
        /// <summary>
        /// Some long running task that requires updates to a client.
        /// </summary>
        /// <param name="ConnectionId"></param>
        public void LongRunningTask(String ConnectionId)
        {
            ShowAlert("Request is received...", ConnectionId);
            System.Threading.Thread.Sleep(5000);
            ShowAlert("Request is queued...", ConnectionId);
            System.Threading.Thread.Sleep(5000);
            ShowAlert("Processing request...", ConnectionId);
            System.Threading.Thread.Sleep(5000);
            ShowAlert("Validating Information...", ConnectionId);
            System.Threading.Thread.Sleep(5000);
            ShowAlert("Cleaning Up...", ConnectionId);
            System.Threading.Thread.Sleep(5000);
            ShowAlert("Request Complete! :)", ConnectionId);
        } // end Show Alert

        /// <summary>
        /// Sends a given message back to the MVC project with the connection id of the client who started
        /// the task.  The MVC project handles how to deliver the message if that client is unavailable.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ConnectionId"></param>
        private void ShowAlert(String Message, String ConnectionId)
        {
            RestClient Client = new RestClient("http://localhost:8888");
            RestRequest Request = new RestRequest("/Listener/SignalR", Method.POST);
            Request.Parameters.Add(new Parameter() { Name = "Message", Type = ParameterType.QueryString, Value = Message });
            Request.Parameters.Add(new Parameter() { Name = "Type", Type = ParameterType.QueryString, Value = "ShowAlert" });
            Request.Parameters.Add(new Parameter() { Name = "ConnectionId", Type = ParameterType.QueryString, Value = ConnectionId });
            IRestResponse Response = Client.Execute(Request);
        } // end send message
    } // end class SignalRTestService
} // end namespace
