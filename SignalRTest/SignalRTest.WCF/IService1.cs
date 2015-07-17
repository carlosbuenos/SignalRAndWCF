using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SignalRTest.WCF
{
    [ServiceContract]
    public interface ISignalRTestService
    {
        [OperationContract]
        void LongRunningTask(String ConnectionId);
        // TODO: Add your service operations here
    } // end interface SignalRTestService
} // end namespace
