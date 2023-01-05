namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandBanListOutput : OpenApiPageOutput<GetIslandBanListItem>
    {
    }

    public class GetIslandBanListItem
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }
    }
}
