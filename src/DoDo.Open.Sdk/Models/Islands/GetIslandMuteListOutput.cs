namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandMuteListOutput : OpenApiPageOutput<GetIslandMuteListItem>
    {

    }

    public class GetIslandMuteListItem
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }
    }
}
