namespace FactoryDesiginPattern
{
    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification();
        public void Notify(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }

    public class EmailNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }

    public class SMSNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new SmsNotification();
        }
    }

    public class PushNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new PushNotification();
        }
    }
}
