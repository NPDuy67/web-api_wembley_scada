﻿using System.Runtime.Serialization;

namespace WembleyScada.Api.Application.Commands.DeviceReferences;

[DataContract]
public class UpdateMFCViewModel
{
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public double Value { get; set; }
    [DataMember]
    public double MinValue { get; set; }
    [DataMember]
    public double MaxValue { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private UpdateMFCViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public UpdateMFCViewModel(string name, double value, double minValue, double maxValue)
    {
        Name = name;
        Value = value;
        MinValue = minValue;
        MaxValue = maxValue;
    }
}
