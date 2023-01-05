using System.Collections.Generic;

namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftShareRatioInfoOutput
    {
        /// <summary>
        /// 默认抽成
        /// </summary>
        public GetGiftShareRatioInfoDefault DefaultRatio { get; set; }

        /// <summary>
        /// 身份组抽成列表
        /// </summary>
        public List<GetGiftShareRatioInfoRole> RoleRatioList { get; set; }
    }

    public class GetGiftShareRatioInfoDefault
    {
        /// <summary>
        ///群抽成
        /// </summary>
        public decimal IslandRatio { get; set; }

        /// <summary>
        /// 被打赏用户抽成
        /// </summary>
        public decimal UserRatio { get; set; }

        /// <summary>
        /// 平台抽成
        /// </summary>
        public decimal PlatformRatio { get; set; }
    }

    public class GetGiftShareRatioInfoRole
    {
        /// <summary>
        /// 身份组ID
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 身份组名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        ///群抽成
        /// </summary>
        public decimal IslandRatio { get; set; }

        /// <summary>
        /// 被打赏用户抽成
        /// </summary>
        public decimal UserRatio { get; set; }

        /// <summary>
        /// 平台抽成
        /// </summary>
        public decimal PlatformRatio { get; set; }
    }
}
