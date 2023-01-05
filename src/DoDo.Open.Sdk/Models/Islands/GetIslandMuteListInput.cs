namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandMuteListInput : OpenApiPageInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }
    }
}
