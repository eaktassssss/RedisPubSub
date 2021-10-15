using StackExchange.Redis;
using System;

namespace RedisPubSub.Publisher
{
    class Program
    {
        async static void Main(string[] args)
        {
            try
            {
                var channel = "message";
                var connection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
                var pubsub = connection.GetSubscriber();
                Console.WriteLine("Message:");
                var message = Console.ReadLine();
                await pubsub.PublishAsync(channel, message, CommandFlags.FireAndForget);
                Console.WriteLine("Successful");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
