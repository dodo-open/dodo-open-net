namespace DoDo.Open.Sdk.Models.Resources;

public record SetResourceUploadInput
{
    /// <summary>
    ///     本地地址 / 网络地址
    /// </summary>
    public string FilePath { get; set; }
}