using RabbitMQ.Client;
using System;
using System.Text;

namespace MQSend
{
    class Program
    {

        public static void Main()
        {
            Console.WriteLine("输入'send'填写发送消息");
            Console.WriteLine("输入'exit'退出");
            while (true)
            {
                Console.WriteLine();
                string text = Console.ReadLine();

                if (text == "send")
                {
                    Console.WriteLine("输入消息");

                    string msg = Console.ReadLine();

                    Console.WriteLine("开始发送");
                    SendMsg(msg); 
                    Console.WriteLine();
                    Console.WriteLine("输入'send'填写发送消息");
                    Console.WriteLine("输入'exit'退出");

                }
                if (text == "exit") return;
            }
        }
        private static void SendMsg(string msg)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = msg;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

        }
    }
}
