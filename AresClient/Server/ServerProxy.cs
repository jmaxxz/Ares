﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ares.Common.Api.DataTypes
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MutablePlayer", Namespace="http://schemas.datacontract.org/2004/07/Ares.Common.Api.DataTypes")]
    public partial class MutablePlayer : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Drawing.Color ClothingColork__BackingFieldField;
        
        private Ares.Common.Api.DataTypes.MutablePosition CurrentPositionk__BackingFieldField;
        
        private double Healthk__BackingFieldField;
        
        private System.Guid Idk__BackingFieldField;
        
        private string Nicknamek__BackingFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<ClothingColor>k__BackingField", IsRequired=true)]
        public System.Drawing.Color ClothingColork__BackingField
        {
            get
            {
                return this.ClothingColork__BackingFieldField;
            }
            set
            {
                this.ClothingColork__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<CurrentPosition>k__BackingField", IsRequired=true)]
        public Ares.Common.Api.DataTypes.MutablePosition CurrentPositionk__BackingField
        {
            get
            {
                return this.CurrentPositionk__BackingFieldField;
            }
            set
            {
                this.CurrentPositionk__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Health>k__BackingField", IsRequired=true)]
        public double Healthk__BackingField
        {
            get
            {
                return this.Healthk__BackingFieldField;
            }
            set
            {
                this.Healthk__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Id>k__BackingField", IsRequired=true)]
        public System.Guid Idk__BackingField
        {
            get
            {
                return this.Idk__BackingFieldField;
            }
            set
            {
                this.Idk__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Nickname>k__BackingField", IsRequired=true)]
        public string Nicknamek__BackingField
        {
            get
            {
                return this.Nicknamek__BackingFieldField;
            }
            set
            {
                this.Nicknamek__BackingFieldField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MutablePosition", Namespace="http://schemas.datacontract.org/2004/07/Ares.Common.Api.DataTypes")]
    public partial class MutablePosition : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double _latitudeField;
        
        private double _longitudeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _latitude
        {
            get
            {
                return this._latitudeField;
            }
            set
            {
                this._latitudeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _longitude
        {
            get
            {
                return this._longitudeField;
            }
            set
            {
                this._longitudeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MutableShot", Namespace="http://schemas.datacontract.org/2004/07/Ares.Common.Api.DataTypes")]
    public partial class MutableShot : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Guid Idk__BackingFieldField;
        
        private byte[] Imagek__BackingFieldField;
        
        private Ares.Common.Api.DataTypes.MutablePlayer Shooterk__BackingFieldField;
        
        private Ares.Common.Api.DataTypes.MutablePlayer Targetk__BackingFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Id>k__BackingField", IsRequired=true)]
        public System.Guid Idk__BackingField
        {
            get
            {
                return this.Idk__BackingFieldField;
            }
            set
            {
                this.Idk__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Image>k__BackingField", IsRequired=true)]
        public byte[] Imagek__BackingField
        {
            get
            {
                return this.Imagek__BackingFieldField;
            }
            set
            {
                this.Imagek__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Shooter>k__BackingField", IsRequired=true)]
        public Ares.Common.Api.DataTypes.MutablePlayer Shooterk__BackingField
        {
            get
            {
                return this.Shooterk__BackingFieldField;
            }
            set
            {
                this.Shooterk__BackingFieldField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Target>k__BackingField", IsRequired=true)]
        public Ares.Common.Api.DataTypes.MutablePlayer Targetk__BackingField
        {
            get
            {
                return this.Targetk__BackingFieldField;
            }
            set
            {
                this.Targetk__BackingFieldField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MutableSignalStrength", Namespace="http://schemas.datacontract.org/2004/07/Ares.Common.Api.DataTypes")]
    public partial class MutableSignalStrength : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double _valueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _value
        {
            get
            {
                return this._valueField;
            }
            set
            {
                this._valueField = value;
            }
        }
    }
}
namespace System.Drawing
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Color", Namespace="http://schemas.datacontract.org/2004/07/System.Drawing")]
    public partial struct Color : System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private short knownColorField;
        
        private string nameField;
        
        private short stateField;
        
        private long valueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short knownColor
        {
            get
            {
                return this.knownColorField;
            }
            set
            {
                this.knownColorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Ares.Common.Api.Server", ConfigurationName="IPlayerManagement")]
public interface IPlayerManagement
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Ares.Common.Api.Server/IPlayerManagement/Join")]
    void Join(Ares.Common.Api.DataTypes.MutablePlayer player);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Ares.Common.Api.Server/IPlayerManagement/Leave")]
    void Leave(Ares.Common.Api.DataTypes.MutablePlayer player);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Ares.Common.Api.Server/IPlayerManagement/GetPlayers", ReplyAction="http://Ares.Common.Api.Server/IPlayerManagement/GetPlayersResponse")]
    Ares.Common.Api.DataTypes.MutablePlayer[] GetPlayers();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IPlayerManagementChannel : IPlayerManagement, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class PlayerManagementClient : System.ServiceModel.ClientBase<IPlayerManagement>, IPlayerManagement
{
    
    public PlayerManagementClient()
    {
    }
    
    public PlayerManagementClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PlayerManagementClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PlayerManagementClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PlayerManagementClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void Join(Ares.Common.Api.DataTypes.MutablePlayer player)
    {
        base.Channel.Join(player);
    }
    
    public void Leave(Ares.Common.Api.DataTypes.MutablePlayer player)
    {
        base.Channel.Leave(player);
    }
    
    public Ares.Common.Api.DataTypes.MutablePlayer[] GetPlayers()
    {
        return base.Channel.GetPlayers();
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Ares.Common.Api.Server", ConfigurationName="IPositionTracker")]
public interface IPositionTracker
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Ares.Common.Api.Server/IPositionTracker/SetPosition")]
    void SetPosition(Ares.Common.Api.DataTypes.MutablePosition position, Ares.Common.Api.DataTypes.MutablePlayer player);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IPositionTrackerChannel : IPositionTracker, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class PositionTrackerClient : System.ServiceModel.ClientBase<IPositionTracker>, IPositionTracker
{
    
    public PositionTrackerClient()
    {
    }
    
    public PositionTrackerClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PositionTrackerClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PositionTrackerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PositionTrackerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void SetPosition(Ares.Common.Api.DataTypes.MutablePosition position, Ares.Common.Api.DataTypes.MutablePlayer player)
    {
        base.Channel.SetPosition(position, player);
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Ares.Common.Api.Server", ConfigurationName="IShotTracker")]
public interface IShotTracker
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Ares.Common.Api.Server/IShotTracker/FireShot", ReplyAction="http://Ares.Common.Api.Server/IShotTracker/FireShotResponse")]
    bool FireShot(Ares.Common.Api.DataTypes.MutableShot shot);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IShotTrackerChannel : IShotTracker, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ShotTrackerClient : System.ServiceModel.ClientBase<IShotTracker>, IShotTracker
{
    
    public ShotTrackerClient()
    {
    }
    
    public ShotTrackerClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ShotTrackerClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ShotTrackerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ShotTrackerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public bool FireShot(Ares.Common.Api.DataTypes.MutableShot shot)
    {
        return base.Channel.FireShot(shot);
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Ares.Common.Api.Server", ConfigurationName="ISignalStrengthTracker")]
public interface ISignalStrengthTracker
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Ares.Common.Api.Server/ISignalStrengthTracker/SetSignalStrength")]
    void SetSignalStrength(Ares.Common.Api.DataTypes.MutableSignalStrength signal, Ares.Common.Api.DataTypes.MutablePlayer player);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ISignalStrengthTrackerChannel : ISignalStrengthTracker, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class SignalStrengthTrackerClient : System.ServiceModel.ClientBase<ISignalStrengthTracker>, ISignalStrengthTracker
{
    
    public SignalStrengthTrackerClient()
    {
    }
    
    public SignalStrengthTrackerClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public SignalStrengthTrackerClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SignalStrengthTrackerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SignalStrengthTrackerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void SetSignalStrength(Ares.Common.Api.DataTypes.MutableSignalStrength signal, Ares.Common.Api.DataTypes.MutablePlayer player)
    {
        base.Channel.SetSignalStrength(signal, player);
    }
}
