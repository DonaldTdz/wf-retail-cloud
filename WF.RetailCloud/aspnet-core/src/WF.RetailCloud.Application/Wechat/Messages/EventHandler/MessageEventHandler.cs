using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Notifications;
using Abp.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.Wechat.Messages.EventHandler
{
    public class MessageEventHandler : IEventHandler<EntityCreatedEventData<WechatMessage>>
        , IEventHandler<EntityUpdatedEventData<WechatMessage>>
        , ITransientDependency
    {
        private IRealTimeNotifier _realTimeNotifier;

        public MessageEventHandler(IRealTimeNotifier realTimeNotifier)
        {
            _realTimeNotifier = realTimeNotifier;
        }

        public void HandleEvent(EntityCreatedEventData<WechatMessage> eventData)
        {
            AsyncHelper.RunSync(async () =>
            {
                UserNotification[] userNotifications = new UserNotification[1];
                userNotifications[0] = new UserNotification()
                {
                    UserId = 2,
                    TenantId = 1,
                    State = UserNotificationState.Unread,
                    Notification = new TenantNotification()
                    {
                        NotificationName = "添加微信回复通知",
                        CreationTime = DateTime.Now,
                        Data = new MessageNotificationData("SignalR:添加微信回复通知" + eventData.Entity.KeyWord)
                    }
                };
                await _realTimeNotifier.SendNotificationsAsync(userNotifications);
            });
            
        }

        public void HandleEvent(EntityUpdatedEventData<WechatMessage> eventData)
        {
            AsyncHelper.RunSync(async () =>
            {
                UserNotification[] userNotifications = new UserNotification[1];
                userNotifications[0] = new UserNotification()
                {
                    UserId = 2,
                    TenantId = 1,
                    State = UserNotificationState.Unread,
                    Notification = new TenantNotification()
                    {
                        NotificationName = "修改微信回复通知",
                        CreationTime = DateTime.Now,
                        Data = new MessageNotificationData("SignalR:修改微信回复通知" + eventData.Entity.KeyWord)
                
                    }
                };
                await _realTimeNotifier.SendNotificationsAsync(userNotifications);
            });
        }
    }
}


