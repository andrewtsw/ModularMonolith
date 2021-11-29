﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EsfApiSdk.AwpXsd
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="awp", ConfigurationName="EsfApiSdk.AwpXsd.AwpXsdService")]
    public interface AwpXsdService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.AwpXsd.queryAwpXsdResponse> queryAwpXsdAsync(EsfApiSdk.AwpXsd.queryAwpXsd request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="awp")]
    public partial class AwpXsdRequest
    {
        
        private awpVersion versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public awpVersion version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="awp")]
    public enum awpVersion
    {
        
        /// <remarks/>
        AwpV1,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="awp")]
    public partial class AwpXsdResponse
    {
        
        private string[] xsdListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("xsd", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public string[] xsdList
        {
            get
            {
                return this.xsdListField;
            }
            set
            {
                this.xsdListField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class queryAwpXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="awp", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.AwpXsd.AwpXsdRequest queryAwpXsdRequest;
        
        public queryAwpXsd()
        {
        }
        
        public queryAwpXsd(EsfApiSdk.AwpXsd.AwpXsdRequest queryAwpXsdRequest)
        {
            this.queryAwpXsdRequest = queryAwpXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class queryAwpXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="queryAwpXsdResponse", Namespace="awp", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.AwpXsd.AwpXsdResponse queryAwpXsdResponse1;
        
        public queryAwpXsdResponse()
        {
        }
        
        public queryAwpXsdResponse(EsfApiSdk.AwpXsd.AwpXsdResponse queryAwpXsdResponse1)
        {
            this.queryAwpXsdResponse1 = queryAwpXsdResponse1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface AwpXsdServiceChannel : EsfApiSdk.AwpXsd.AwpXsdService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class AwpXsdServiceClient : System.ServiceModel.ClientBase<EsfApiSdk.AwpXsd.AwpXsdService>, EsfApiSdk.AwpXsd.AwpXsdService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AwpXsdServiceClient() : 
                base(AwpXsdServiceClient.GetDefaultBinding(), AwpXsdServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.AwpXsdServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AwpXsdServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(AwpXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), AwpXsdServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AwpXsdServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AwpXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AwpXsdServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AwpXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AwpXsdServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EsfApiSdk.AwpXsd.queryAwpXsdResponse> EsfApiSdk.AwpXsd.AwpXsdService.queryAwpXsdAsync(EsfApiSdk.AwpXsd.queryAwpXsd request)
        {
            return base.Channel.queryAwpXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.AwpXsd.queryAwpXsdResponse> queryAwpXsdAsync(EsfApiSdk.AwpXsd.AwpXsdRequest queryAwpXsdRequest)
        {
            EsfApiSdk.AwpXsd.queryAwpXsd inValue = new EsfApiSdk.AwpXsd.queryAwpXsd();
            inValue.queryAwpXsdRequest = queryAwpXsdRequest;
            return ((EsfApiSdk.AwpXsd.AwpXsdService)(this)).queryAwpXsdAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AwpXsdServicePort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AwpXsdServicePort))
            {
                return new System.ServiceModel.EndpointAddress("https://test3.esf.kgd.gov.kz:8443/esf-web/ws/api1/AwpXsdService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AwpXsdServiceClient.GetBindingForEndpoint(EndpointConfiguration.AwpXsdServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AwpXsdServiceClient.GetEndpointAddress(EndpointConfiguration.AwpXsdServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            AwpXsdServicePort,
        }
    }
}
