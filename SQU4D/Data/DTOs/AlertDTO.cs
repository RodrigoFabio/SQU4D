using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class AlertDTO
{
    [JsonPropertyName("id")]
    public int id { get; set; }
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    public Duration Duration { get; set; }
    public string? Occurrences { get; set; }
    public Duration EngineHours { get; set; }
    public int MachineLinearTime { get; set; }
    public string? Bus { get; set; }
    public DateTime? Time { get; set; }
    public Location Location { get; set; }
    public string? Color { get; set; }
    public string? Severity { get; set; }
    public string? AcknowledgementStatus { get; set; }
    public bool Ignored { get; set; }
    public bool Invisible { get; set; }
    public Link Link { get; set; }
    public Definition Definition { get; set; }
}

public class Duration
{
    [JsonPropertyName("@type")]
    public string? @Type { get; set; }
    [JsonPropertyName("valueAsInteger")]
    public int ValueAsInteger { get; set; }
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}

public class EngineHours
{
    [JsonPropertyName("@type")]
    public string? @Type { get; set; }
    [JsonPropertyName("valueAsDouble")]
    public double ValueAsDouble { get; set; }
    public string? Unit { get; set; }
}

public class Definition
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    [JsonPropertyName("suspectParameterName")]
    public string? SuspectParameterName { get; set; }
    [JsonPropertyName("failureModeIndicator")]
    public string? FailureModeIndicator { get; set; }
    [JsonPropertyName("bus")]
    public string? Bus { get; set; }
    [JsonPropertyName("sourceAddress")]
    public string? SourceAddress { get; set; }
    [JsonPropertyName("threeLetterAcronym")]
    public string? ThreeLetterAcronym { get; set; }
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("links")]
    public Link DefinitionLink { get; set; }
}

public class Location
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    [JsonPropertyName("lat")]
    public double Lat { get; set; }
    [JsonPropertyName("lon")]
    public double Lon { get; set; }
}

public class Link
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    [JsonPropertyName("rel")]
    public string? Rel { get; set; }
    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}


