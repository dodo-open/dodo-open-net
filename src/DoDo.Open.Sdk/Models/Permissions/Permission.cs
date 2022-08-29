using System.ComponentModel;

namespace DoDo.Open.Sdk.Models.Permissions
{
    /// <summary>
    /// 权限枚举
    /// </summary>
    public enum Permission
    {
        #region 通用权限

        /// <summary>
        /// 管理频道与分组
        /// </summary>
        [Description("管理频道与分组")]
        ManageChannels = 1 << 0,

        /// <summary>
        /// 编辑频道
        /// </summary>
        [Description("编辑频道")]
        EditChannels = 1 << 1,

        /// <summary>
        /// 查看频道
        /// </summary>
        [Description("查看频道")]
        ViewChannel = 1 << 6,

        /// <summary>
        /// 管理权限与身份组
        /// </summary>
        [Description("管理权限与身份组")]
        ManageRoles = 1 << 7,

        /// <summary>
        /// 管理群表情包
        /// </summary>
        [Description("管理群表情包")]
        ManageEmojis = 1 << 8,

        /// <summary>
        /// @所有人和身份组
        /// </summary>
        [Description("@所有人和身份组")]
        Mention = 1 << 9,

        /// <summary>
        /// 搜索内容
        /// </summary>
        [Description("搜索内容")]
        SearchArticle = 1 << 20,

        #endregion

        #region 成员管理

        /// <summary>
        /// 管理成员
        /// </summary>
        [Description("管理成员")]
        ManageMembers = 1 << 2,

        /// <summary>
        /// 修改群昵称
        /// </summary>
        [Description("修改群昵称")]
        ModifyNickname = 1 << 4,

        /// <summary>
        /// 管理群昵称
        /// </summary>
        [Description("管理群昵称")]
        ManageNickname = 1 << 5,

        #endregion

        #region 文字频道

        /// <summary>
        /// 发送消息
        /// </summary>
        [Description("发送消息")]
        SendMessages = 1 << 10,

        /// <summary>
        /// 管理消息
        /// </summary>
        [Description("管理消息")]
        ManageMessages = 1 << 11,

        /// <summary>
        /// 添加新反应
        /// </summary>
        [Description("添加新反应")]
        CreateReaction = 1 << 12,

        #endregion

        #region 帖子频道

        /// <summary>
        /// 发布帖子
        /// </summary>
        [Description("发布帖子")]
        PublishArticles = 1 << 13,

        /// <summary>
        /// 发布评论
        /// </summary>
        [Description("发布评论")]
        PublishComments = 1 << 21,

        /// <summary>
        /// 管理帖子
        /// </summary>
        [Description("管理帖子")]
        ManageArticles = 1 << 14,

        /// <summary>
        /// 删除帖子
        /// </summary>
        [Description("删除帖子")]
        DeleteArticles = 1 << 15,

        #endregion

        #region 语音频道

        /// <summary>
        /// 连接
        /// </summary>
        [Description("连接")]
        Connect = 1 << 16,

        /// <summary>
        /// 说话
        /// </summary>
        [Description("说话")]
        Speak = 1 << 17,

        /// <summary>
        /// 管理语音
        /// </summary>
        [Description("管理语音")]
        ManageVoices = 1 << 18,

        /// <summary>
        /// 移动成员
        /// </summary>
        [Description("移动成员")]
        MoveMembers = 1 << 19,

        #endregion

        #region 高级权限

        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        Administrator = 1 << 3,

        #endregion
    }
}
