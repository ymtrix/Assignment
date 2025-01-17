﻿using System.ServiceModel;
using System.Xml ;

namespace ABM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IABMPayloadService" in both code and config file together.
    [ServiceContract]
    public interface IXmlPayloadService
    {
        [OperationContract]
        int GetStatusCodeOfXMLPayload(XmlElement xmlElement);
    }
}
