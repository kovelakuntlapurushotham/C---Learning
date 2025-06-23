using FactoryDesiginPattern;

NotificationFactory emailFactory = new EmailNotificationFactory();
emailFactory.Notify("This is an email notification.");
INotification notification = new EmailNotification();
notification.Send("tj");

NotificationFactory smsFactory = new SMSNotificationFactory();
smsFactory.Notify("This is an SMS notification.");

NotificationFactory pushFactory = new PushNotificationFactory();
pushFactory.Notify("This is a push notification.");