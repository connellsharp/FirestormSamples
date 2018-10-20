using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirestormSample.Domain.Messages;
using Newtonsoft.Json;

namespace FirestormSample.Api
{
    public class ConsoleMessagePublisher : IMessagePublisher
    {
        public static IList<object> Messages { get; } = new List<object>();

        public Task PublishAsync<TMessage>(TMessage message)
        {
            Messages.Add(message);
            
            Console.WriteLine("Published message:");
            Console.WriteLine(JsonConvert.SerializeObject(message));
            Console.WriteLine();
            
            return Task.CompletedTask;
        }
    }
}