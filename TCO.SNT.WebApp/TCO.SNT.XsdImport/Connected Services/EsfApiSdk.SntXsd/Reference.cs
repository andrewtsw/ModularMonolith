﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EsfApiSdk.SntXsd
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="snt", ConfigurationName="EsfApiSdk.SntXsd.SntXsdService")]
    public interface SntXsdService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntXsdResponse> querySntXsdAsync(EsfApiSdk.SntXsd.querySntXsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntHistoryXsdResponse> querySntHistoryXsdAsync(EsfApiSdk.SntXsd.querySntHistoryXsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntUploadInfoXsdResponse> querySntUploadInfoXsdAsync(EsfApiSdk.SntXsd.querySntUploadInfoXsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntV1XsdResponse> querySntV1XsdAsync(EsfApiSdk.SntXsd.querySntV1Xsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntInfoXsdResponse> querySntInfoXsdAsync(EsfApiSdk.SntXsd.querySntInfoXsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntSummaryXsdResponse> querySntSummaryXsdAsync(EsfApiSdk.SntXsd.querySntSummaryXsd request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntChangeStatusResultXsdResponse> querySntChangeStatusResultXsdAsync(EsfApiSdk.SntXsd.querySntChangeStatusResultXsd request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="snt")]
    public partial class SntXsdRequest
    {
        
        private string versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string version
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="snt")]
    public partial class XsdRequest
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="snt")]
    public partial class XsdResponse
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.SntXsdRequest SntXsdRequest;
        
        public querySntXsd()
        {
        }
        
        public querySntXsd(EsfApiSdk.SntXsd.SntXsdRequest SntXsdRequest)
        {
            this.SntXsdRequest = SntXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntXsdResponse1;
        
        public querySntXsdResponse()
        {
        }
        
        public querySntXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntXsdResponse1)
        {
            this.querySntXsdResponse1 = querySntXsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntHistoryXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdRequest querySntHistoryXsdRequest;
        
        public querySntHistoryXsd()
        {
        }
        
        public querySntHistoryXsd(EsfApiSdk.SntXsd.XsdRequest querySntHistoryXsdRequest)
        {
            this.querySntHistoryXsdRequest = querySntHistoryXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntHistoryXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntHistoryXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntHistoryXsdResponse1;
        
        public querySntHistoryXsdResponse()
        {
        }
        
        public querySntHistoryXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntHistoryXsdResponse1)
        {
            this.querySntHistoryXsdResponse1 = querySntHistoryXsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntUploadInfoXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdRequest querySntUploadInfoXsdRequest;
        
        public querySntUploadInfoXsd()
        {
        }
        
        public querySntUploadInfoXsd(EsfApiSdk.SntXsd.XsdRequest querySntUploadInfoXsdRequest)
        {
            this.querySntUploadInfoXsdRequest = querySntUploadInfoXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntUploadInfoXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntUploadInfoXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntUploadInfoXsdResponse1;
        
        public querySntUploadInfoXsdResponse()
        {
        }
        
        public querySntUploadInfoXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntUploadInfoXsdResponse1)
        {
            this.querySntUploadInfoXsdResponse1 = querySntUploadInfoXsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntV1Xsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.SntXsdRequest querySntV1XsdRequest;
        
        public querySntV1Xsd()
        {
        }
        
        public querySntV1Xsd(EsfApiSdk.SntXsd.SntXsdRequest querySntV1XsdRequest)
        {
            this.querySntV1XsdRequest = querySntV1XsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntV1XsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntV1XsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntV1XsdResponse1;
        
        public querySntV1XsdResponse()
        {
        }
        
        public querySntV1XsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntV1XsdResponse1)
        {
            this.querySntV1XsdResponse1 = querySntV1XsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntInfoXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.SntXsdRequest querySntInfoXsdRequest;
        
        public querySntInfoXsd()
        {
        }
        
        public querySntInfoXsd(EsfApiSdk.SntXsd.SntXsdRequest querySntInfoXsdRequest)
        {
            this.querySntInfoXsdRequest = querySntInfoXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntInfoXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntInfoXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntInfoXsdResponse1;
        
        public querySntInfoXsdResponse()
        {
        }
        
        public querySntInfoXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntInfoXsdResponse1)
        {
            this.querySntInfoXsdResponse1 = querySntInfoXsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntSummaryXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdRequest querySntSummaryXsdRequest;
        
        public querySntSummaryXsd()
        {
        }
        
        public querySntSummaryXsd(EsfApiSdk.SntXsd.XsdRequest querySntSummaryXsdRequest)
        {
            this.querySntSummaryXsdRequest = querySntSummaryXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntSummaryXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntSummaryXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntSummaryXsdResponse1;
        
        public querySntSummaryXsdResponse()
        {
        }
        
        public querySntSummaryXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntSummaryXsdResponse1)
        {
            this.querySntSummaryXsdResponse1 = querySntSummaryXsdResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntChangeStatusResultXsd
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdRequest querySntChangeStatusResultXsdRequest;
        
        public querySntChangeStatusResultXsd()
        {
        }
        
        public querySntChangeStatusResultXsd(EsfApiSdk.SntXsd.XsdRequest querySntChangeStatusResultXsdRequest)
        {
            this.querySntChangeStatusResultXsdRequest = querySntChangeStatusResultXsdRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class querySntChangeStatusResultXsdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="querySntChangeStatusResultXsdResponse", Namespace="snt", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EsfApiSdk.SntXsd.XsdResponse querySntChangeStatusResultXsdResponse1;
        
        public querySntChangeStatusResultXsdResponse()
        {
        }
        
        public querySntChangeStatusResultXsdResponse(EsfApiSdk.SntXsd.XsdResponse querySntChangeStatusResultXsdResponse1)
        {
            this.querySntChangeStatusResultXsdResponse1 = querySntChangeStatusResultXsdResponse1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface SntXsdServiceChannel : EsfApiSdk.SntXsd.SntXsdService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class SntXsdServiceClient : System.ServiceModel.ClientBase<EsfApiSdk.SntXsd.SntXsdService>, EsfApiSdk.SntXsd.SntXsdService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SntXsdServiceClient() : 
                base(SntXsdServiceClient.GetDefaultBinding(), SntXsdServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.SntXsdServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SntXsdServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SntXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), SntXsdServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SntXsdServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SntXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SntXsdServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SntXsdServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SntXsdServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntXsdResponse> querySntXsdAsync(EsfApiSdk.SntXsd.querySntXsd request)
        {
            return base.Channel.querySntXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntHistoryXsdResponse> querySntHistoryXsdAsync(EsfApiSdk.SntXsd.querySntHistoryXsd request)
        {
            return base.Channel.querySntHistoryXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntUploadInfoXsdResponse> querySntUploadInfoXsdAsync(EsfApiSdk.SntXsd.querySntUploadInfoXsd request)
        {
            return base.Channel.querySntUploadInfoXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntV1XsdResponse> querySntV1XsdAsync(EsfApiSdk.SntXsd.querySntV1Xsd request)
        {
            return base.Channel.querySntV1XsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntInfoXsdResponse> querySntInfoXsdAsync(EsfApiSdk.SntXsd.querySntInfoXsd request)
        {
            return base.Channel.querySntInfoXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntSummaryXsdResponse> querySntSummaryXsdAsync(EsfApiSdk.SntXsd.querySntSummaryXsd request)
        {
            return base.Channel.querySntSummaryXsdAsync(request);
        }
        
        public System.Threading.Tasks.Task<EsfApiSdk.SntXsd.querySntChangeStatusResultXsdResponse> querySntChangeStatusResultXsdAsync(EsfApiSdk.SntXsd.querySntChangeStatusResultXsd request)
        {
            return base.Channel.querySntChangeStatusResultXsdAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.SntXsdServicePort))
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
            if ((endpointConfiguration == EndpointConfiguration.SntXsdServicePort))
            {
                return new System.ServiceModel.EndpointAddress("https://test3.esf.kgd.gov.kz:8443/esf-web/ws/api1/SntXsdService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SntXsdServiceClient.GetBindingForEndpoint(EndpointConfiguration.SntXsdServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SntXsdServiceClient.GetEndpointAddress(EndpointConfiguration.SntXsdServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            SntXsdServicePort,
        }
    }
}