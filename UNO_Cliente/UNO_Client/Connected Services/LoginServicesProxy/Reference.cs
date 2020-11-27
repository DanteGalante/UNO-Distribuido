﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UNO_Client.LoginServicesProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/UNO_DB")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] avatarImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idPlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> isBannedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> isLoggedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastnamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] avatarImage {
            get {
                return this.avatarImageField;
            }
            set {
                if ((object.ReferenceEquals(this.avatarImageField, value) != true)) {
                    this.avatarImageField = value;
                    this.RaisePropertyChanged("avatarImage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idPlayer {
            get {
                return this.idPlayerField;
            }
            set {
                if ((this.idPlayerField.Equals(value) != true)) {
                    this.idPlayerField = value;
                    this.RaisePropertyChanged("idPlayer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> isBanned {
            get {
                return this.isBannedField;
            }
            set {
                if ((this.isBannedField.Equals(value) != true)) {
                    this.isBannedField = value;
                    this.RaisePropertyChanged("isBanned");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> isLogged {
            get {
                return this.isLoggedField;
            }
            set {
                if ((this.isLoggedField.Equals(value) != true)) {
                    this.isLoggedField = value;
                    this.RaisePropertyChanged("isLogged");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastnames {
            get {
                return this.lastnamesField;
            }
            set {
                if ((object.ReferenceEquals(this.lastnamesField, value) != true)) {
                    this.lastnamesField = value;
                    this.RaisePropertyChanged("lastnames");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServicesProxy.ILoginServices", CallbackContract=typeof(UNO_Client.LoginServicesProxy.ILoginServicesCallback))]
    public interface ILoginServices {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ILoginServices/Login")]
        void Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ILoginServices/Login")]
        System.Threading.Tasks.Task LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginServices/IsLogged", ReplyAction="http://tempuri.org/ILoginServices/IsLoggedResponse")]
        bool IsLogged(UNO_Client.LoginServicesProxy.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginServices/IsLogged", ReplyAction="http://tempuri.org/ILoginServices/IsLoggedResponse")]
        System.Threading.Tasks.Task<bool> IsLoggedAsync(UNO_Client.LoginServicesProxy.Player player);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginServicesCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginServices/LoginVerification", ReplyAction="http://tempuri.org/ILoginServices/LoginVerificationResponse")]
        void LoginVerification(bool result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginServicesChannel : UNO_Client.LoginServicesProxy.ILoginServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginServicesClient : System.ServiceModel.DuplexClientBase<UNO_Client.LoginServicesProxy.ILoginServices>, UNO_Client.LoginServicesProxy.ILoginServices {
        
        public LoginServicesClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public LoginServicesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public LoginServicesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServicesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServicesClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Login(string username, string password) {
            base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public bool IsLogged(UNO_Client.LoginServicesProxy.Player player) {
            return base.Channel.IsLogged(player);
        }
        
        public System.Threading.Tasks.Task<bool> IsLoggedAsync(UNO_Client.LoginServicesProxy.Player player) {
            return base.Channel.IsLoggedAsync(player);
        }
    }
}
