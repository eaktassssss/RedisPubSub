using StackExchange.Redis;
using System;

namespace RedisPubSub.Subscriber
{
    class Program
    {
        async static void Main(string[] args)
        {
            try
            {
                var Channel = "message";
                var connection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
                var pubsub = connection.GetSubscriber();
                await pubsub.SubscribeAsync(Channel, (channel, message) => Console.WriteLine(message));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
