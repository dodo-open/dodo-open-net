﻿using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Roles;

public record GetRoleListInput
{
    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }
}