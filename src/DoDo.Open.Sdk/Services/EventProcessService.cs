﻿using System;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

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
        /// 消息接收
        /// </summary>
        /// <param name="message"></param>
        internal virtual void Received(string message)
        {
            Console.WriteLine($"{message}\n");

            var eventSubjectResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBase>>(message);
            if (eventSubjectResult == null) return;

            if (eventSubjectResult.Type == EventSubjectDataTypeConst.Business)
            {
                var eventSubjectDataResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyBase>>>(message);
                if (eventSubjectDataResult == null) return;

                if (eventSubjectDataResult.Data.EventType == EventTypeConst.PersonalMessage)
                {
                    var eventBodyResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyBase>>>>(message);
                    if (eventBodyResult == null) return;

                    var eventBody = eventBodyResult.Data.EventBody;

                    if (eventBody.MessageType == MessageTypeConst.Text)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyText>>>>(message);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Picture)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyPicture>>>>(message);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Video)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyVideo>>>>(message);
                        if (messageResult == null) return;
                        PersonalMessageEvent(messageResult);
                    }
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelMessage)
                {
                    var eventBodyResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyBase>>>>(message);
                    if (eventBodyResult == null) return;

                    var eventBody = eventBodyResult.Data.EventBody;

                    if (eventBody.MessageType == MessageTypeConst.Text)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyText>>>>(message);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Picture)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyPicture>>>>(message);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                    else if (eventBody.MessageType == MessageTypeConst.Video)
                    {
                        var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyVideo>>>>(message);
                        if (messageResult == null) return;
                        ChannelMessageEvent(messageResult);
                    }
                }
                else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MessageReaction)
                {
                    var eventBodyResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>>>(message);
                    if (eventBodyResult == null) return;
                    MessageReactionEvent(eventBodyResult);
                }
            }
        }

        /// <summary>
        /// 个人消息事件-文本消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void PersonalMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyText>>> input)
        {

        }

        /// <summary>
        /// 个人消息事件-图片消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void PersonalMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyPicture>>> input)
        {

        }

        /// <summary>
        /// 个人消息事件-视频消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void PersonalMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyVideo>>> input)
        {

        }

        /// <summary>
        /// 频道消息事件-文本消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyText>>> input)
        {

        }

        /// <summary>
        /// 频道消息事件-图片消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyPicture>>> input)
        {

        }

        /// <summary>
        /// 频道消息事件-视频消息
        /// </summary>
        /// <param name="input"></param>
        public virtual void ChannelMessageEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyVideo>>> input)
        {

        }

        /// <summary>
        /// 消息反应事件
        /// </summary>
        /// <param name="input"></param>
        public virtual void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
        {

        }
    }
}
