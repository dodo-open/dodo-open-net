using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 事件处理服务
    /// </summary>
    public abstract class EventProcessService
    {
        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="message"></param>
        public abstract void Connected(string message);

        /// <summary>
        /// 连接断开
        /// </summary>
        /// <param name="message"></param>
        public abstract void Disconnected(string message);

        /// <summary>
        /// 断线重连
        /// </summary>
        /// <param name="message"></param>
        public abstract void Reconnected(string message);

        /// <summary>
        /// 异常反馈
        /// </summary>
        /// <param name="message"></param>
        public abstract void Exception(string message);

        /// <summary>
        /// 消息接收 - 内部
        /// </summary>
        /// <param name="message"></param>
        internal virtual void ReceivedInternal(string message)
        {
            Received(message);

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var eventSubjectResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBase>>(message, jsonSerializerOptions);
            if (eventSubjectResult == null) return;

            if (eventSubjectResult.Type == EventSubjectDataTypeConst.Business)
            {
                var eventSubjectDataResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyBase>>>(message, jsonSerializerOptions);
                if (eventSubjectDataResult == null) return;

                if (eventSubjectDataResult.Data.EventType == EventTypeConst.PersonalMessage)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyBase>>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;

                    var eventBody = eventBodyResult.Data.EventBody;

                    if (eventBody.MessageType == MessageTypeConst.Text)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyText>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Picture)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyPicture>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Video)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyVideo>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelMessage)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyBase>>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;

                    var eventBody = eventBodyResult.Data.EventBody;

                    if (eventBody.MessageType == MessageTypeConst.Text)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyText>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Picture)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyPicture>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Video)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyVideo>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Share)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyShare>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.File)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyFile>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Card)
                    {
                        var messageResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyCard>>>>(message, jsonSerializerOptions);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MessageReaction)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    MessageReactionEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.CardMessageButtonClick)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageButtonClick>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    CardMessageButtonClickEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.CardMessageFormSubmit)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageFormSubmit>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    CardMessageFormSubmitEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.CardMessageListSubmit)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageListSubmit>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    CardMessageListSubmitEvent(eventBodyResult);
                }

                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelVoiceMemberJoin)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberJoin>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    ChannelVoiceMemberJoinEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelVoiceMemberLeave)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberLeave>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    ChannelVoiceMemberLeaveEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelArticle)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticle>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    ChannelArticleEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelArticleComment)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticleComment>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    ChannelArticleCommentEvent(eventBodyResult);
                }

                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberJoin)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    MemberJoinEvent(eventBodyResult);
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberLeave)
                {
                    var eventBodyResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>>>(message, jsonSerializerOptions);
                    if (eventBodyResult == null) return;
                    MemberLeaveEvent(eventBodyResult);
                }
            }
        }

        /// <summary>
        /// 消息接收
        /// </summary>
        /// <param name="message"></param>
        public virtual void Received(string message)
        {
            
        }

        /// <summary>
        /// 私信事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
            where T : MessageBodyBase
        {

        }

        /// <summary>
        /// 消息事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        where T : MessageBodyBase
        {

        }

        /// <summary>
        /// 消息表情反应事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
        {

        }

        /// <summary>
        /// 卡片消息按钮事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void CardMessageButtonClickEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageButtonClick>> input)
        {

        }

        /// <summary>
        /// 卡片消息表单回传事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void CardMessageFormSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageFormSubmit>> input)
        {

        }

        /// <summary>
        /// 卡片消息列表回传事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void CardMessageListSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageListSubmit>> input)
        {

        }

        /// <summary>
        /// 成员加入语音频道事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelVoiceMemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberJoin>> input)
        {

        }

        /// <summary>
        /// 成员退出语音频道事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelVoiceMemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberLeave>> input)
        {

        }

        /// <summary>
        /// 帖子发布事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelArticleEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticle>> input)
        {

        }

        /// <summary>
        /// 帖子评论回复事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelArticleCommentEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticleComment>> input)
        {

        }

        /// <summary>
        /// 成员加入事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
        {

        }

        /// <summary>
        /// 成员退出事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
        {

        }
    }
}
