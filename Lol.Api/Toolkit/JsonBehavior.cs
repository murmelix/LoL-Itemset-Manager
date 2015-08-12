using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Toolkit
{
    public class JsonBehavior : Attribute, IOperationBehavior 
    {
        public  Type ResultType{get;set;}
        
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
            clientOperation.Formatter = new JsonClientFormatter(clientOperation.Formatter, operationDescription, ResultType); 
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
