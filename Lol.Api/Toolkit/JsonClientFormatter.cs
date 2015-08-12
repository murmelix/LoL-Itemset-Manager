using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lol.Api.Toolkit
{
    public class JsonClientFormatter : IClientMessageFormatter
    {
        private OperationDescription _operationDescription;
        private IClientMessageFormatter _actual;
        private Type _resultType;
        
        public JsonClientFormatter(IClientMessageFormatter clientMessageFormatter, OperationDescription operationDescription, Type _resultType)
        {
            this._actual = clientMessageFormatter;
            this._operationDescription = operationDescription;
            this._resultType = _resultType;
        }


        public object DeserializeReply(Message message, object[] parameters)
        {           
            var bodyReader = message.GetReaderAtBodyContents();
            XmlDocument bodyDoc = new XmlDocument();
            bodyDoc.Load(bodyReader);

            var xe = XElement.Parse(bodyDoc.InnerXml);
            var raw = StripNS(xe).ToString();
            var tr = new StringReader(raw);
            using (tr)
            {
                var xs = new XmlSerializer(_resultType, new XmlRootAttribute("root"));
                return xs.Deserialize(tr);
            }
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            return _actual.SerializeRequest(messageVersion, parameters);
        }

        static XElement StripNS(XElement root)
        {
            return new XElement(
                root.Name.LocalName,
                root.HasElements ?
                    root.Elements().Select(el => StripNS(el)) :
                    (object)root.Value
            );
        }
    }
}
