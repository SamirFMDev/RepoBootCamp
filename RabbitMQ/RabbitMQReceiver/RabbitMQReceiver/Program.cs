using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "DESKTOP-F2U20HC",
                UserName = "admin",
                Password = "admin"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            FanoutExchangeReceiver.Consume(channel);

            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "hello",
            //                         durable: false,
            //                         exclusive: false,
            //                         autoDelete: false,
            //                         arguments: null);

                //    var consumer = new EventingBasicConsumer(channel);
                //    consumer.Received += (model, ea) =>
                //    {
                //        var body = ea.Body.ToArray();
                //        var message = Encoding.UTF8.GetString(body);
                //        Console.WriteLine(" [x] Received {0}", message);
                //    };
                //    channel.BasicConsume(queue: "hello",
                //                         autoAck: true,
                //                         consumer: consumer);

                //    Console.WriteLine(" Press [enter] to exit.");
                //    Console.ReadLine();
                //}
        }
    }
}
