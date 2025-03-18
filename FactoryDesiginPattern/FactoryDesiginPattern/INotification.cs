namespace FactoryDesiginPattern
{
    public interface INotification
    {
        void Send(string message);
    }


    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email Notification: " + message);
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS Notification: " + message);
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification: " + message);
        }
    }
}
