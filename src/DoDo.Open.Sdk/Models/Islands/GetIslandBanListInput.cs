namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandBanListInput : OpenApiPageInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }
    }
}
