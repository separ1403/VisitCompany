﻿using Newtonsoft.Json;

namespace ServiceHost.Areas.Administration.Pages;

public class Chart
{
    [JsonProperty(PropertyName = "label")] public string Label { get; set; }

    [JsonProperty(PropertyName = "data")] public List<double> Data { get; set; }

    [JsonProperty(PropertyName = "backgroundColor")]
    public string[] BackgroundColor { get; set; }

    [JsonProperty(PropertyName = "borderColor")]
    public string BorderColor { get; set; }
}