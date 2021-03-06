//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VsSdk.Version
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="namespace.vstore", ConfigurationName="VsSdk.Version.VstoreVersionService")]
    public interface VstoreVersionService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(errorDescription[]))]
        System.Threading.Tasks.Task<VsSdk.Version.getErrorCodesResponse> getErrorCodesAsync(VsSdk.Version.getErrorCodes request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(errorDescription[]))]
        System.Threading.Tasks.Task<VsSdk.Version.getUFormVersionResponse> getUFormVersionAsync(VsSdk.Version.getUFormVersion request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(errorDescription[]))]
        System.Threading.Tasks.Task<VsSdk.Version.getVersionResponse> getVersionAsync(VsSdk.Version.getVersion request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(errorDescription[]))]
        System.Threading.Tasks.Task<VsSdk.Version.getApiVersionResponse> getApiVersionAsync(VsSdk.Version.getApiVersion request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="namespace.vstore")]
    public partial class errorCodesRequest
    {
        
        private string languageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="namespace.vstore")]
    public partial class versionResponse
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="namespace.vstore")]
    public partial class versionRequest
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="namespace.vstore")]
    public partial class errorDescription
    {
        
        private string errorCodeField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string errorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="namespace.vstore")]
    public partial class errorCodesResponse
    {
        
        private errorDescription[] errorDescriptionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public errorDescription[] errorDescriptions
        {
            get
            {
                return this.errorDescriptionsField;
            }
            set
            {
                this.errorDescriptionsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getErrorCodes
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.errorCodesRequest errorCodesRequest;
        
        public getErrorCodes()
        {
        }
        
        public getErrorCodes(VsSdk.Version.errorCodesRequest errorCodesRequest)
        {
            this.errorCodesRequest = errorCodesRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getErrorCodesResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.errorCodesResponse errorCodesResponse;
        
        public getErrorCodesResponse()
        {
        }
        
        public getErrorCodesResponse(VsSdk.Version.errorCodesResponse errorCodesResponse)
        {
            this.errorCodesResponse = errorCodesResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getUFormVersion
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.versionRequest uFormVersionRequest;
        
        public getUFormVersion()
        {
        }
        
        public getUFormVersion(VsSdk.Version.versionRequest uFormVersionRequest)
        {
            this.uFormVersionRequest = uFormVersionRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getUFormVersionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.versionResponse uFormVersionResponse;
        
        public getUFormVersionResponse()
        {
        }
        
        public getUFormVersionResponse(VsSdk.Version.versionResponse uFormVersionResponse)
        {
            this.uFormVersionResponse = uFormVersionResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getVersion
    {
        
        public getVersion()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getVersionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.versionResponse versionResponse;
        
        public getVersionResponse()
        {
        }
        
        public getVersionResponse(VsSdk.Version.versionResponse versionResponse)
        {
            this.versionResponse = versionResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getApiVersion
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.versionRequest apiVersionRequest;
        
        public getApiVersion()
        {
        }
        
        public getApiVersion(VsSdk.Version.versionRequest apiVersionRequest)
        {
            this.apiVersionRequest = apiVersionRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getApiVersionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="namespace.vstore", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public VsSdk.Version.versionResponse apiVersionResponse;
        
        public getApiVersionResponse()
        {
        }
        
        public getApiVersionResponse(VsSdk.Version.versionResponse apiVersionResponse)
        {
            this.apiVersionResponse = apiVersionResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface VstoreVersionServiceChannel : VsSdk.Version.VstoreVersionService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class VstoreVersionServiceClient : System.ServiceModel.ClientBase<VsSdk.Version.VstoreVersionService>, VsSdk.Version.VstoreVersionService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public VstoreVersionServiceClient() : 
                base(VstoreVersionServiceClient.GetDefaultBinding(), VstoreVersionServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.VstoreVersionServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VstoreVersionServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(VstoreVersionServiceClient.GetBindingForEndpoint(endpointConfiguration), VstoreVersionServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VstoreVersionServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(VstoreVersionServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VstoreVersionServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(VstoreVersionServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VstoreVersionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<VsSdk.Version.getErrorCodesResponse> getErrorCodesAsync(VsSdk.Version.getErrorCodes request)
        {
            return base.Channel.getErrorCodesAsync(request);
        }
        
        public System.Threading.Tasks.Task<VsSdk.Version.getUFormVersionResponse> getUFormVersionAsync(VsSdk.Version.getUFormVersion request)
        {
            return base.Channel.getUFormVersionAsync(request);
        }
        
        public System.Threading.Tasks.Task<VsSdk.Version.getVersionResponse> getVersionAsync(VsSdk.Version.getVersion request)
        {
            return base.Channel.getVersionAsync(request);
        }
        
        public System.Threading.Tasks.Task<VsSdk.Version.getApiVersionResponse> getApiVersionAsync(VsSdk.Version.getApiVersion request)
        {
            return base.Channel.getApiVersionAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.VstoreVersionServicePort))
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
            if ((endpointConfiguration == EndpointConfiguration.VstoreVersionServicePort))
            {
                return new System.ServiceModel.EndpointAddress("https://esf.gov.kz:8443/esf-web/vstore-ws/api1/VstoreVersionService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return VstoreVersionServiceClient.GetBindingForEndpoint(EndpointConfiguration.VstoreVersionServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return VstoreVersionServiceClient.GetEndpointAddress(EndpointConfiguration.VstoreVersionServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            VstoreVersionServicePort,
        }
    }
}
