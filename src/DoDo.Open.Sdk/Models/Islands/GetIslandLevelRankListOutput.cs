namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandLevelRankListOutput
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 排名，返回前100名
        /// </summary>
        public int Rank { get; set; }
    }
}
