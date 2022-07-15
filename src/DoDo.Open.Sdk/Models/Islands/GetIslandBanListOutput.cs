using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandBanListOutput
    {
        public GetIslandBanListOutput()
        {
            List = new List<GetIslandBanListItem>();
        }

        /// <summary>
        /// 最大ID值
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// 成员列表
        /// </summary>
        public List<GetIslandBanListItem> List { get; set; }
    }

    public class GetIslandBanListItem
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonPropertyName("dodoId")]
        public string DodoId { get; set; }
    }
}
