using System.Collections.Generic;
namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandMuteListOutput
    {
        public GetIslandMuteListOutput()
        {
            List = new List<GetIslandMuteListItem>();
        }

        /// <summary>
        /// 最大ID值
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// 成员列表
        /// </summary>
        public List<GetIslandMuteListItem> List { get; set; }
    }

    public class GetIslandMuteListItem
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }
    }
}
