// See https://aka.ms/new-console-template for more information
using EasyNetQ;
using FudbalskiKlub.Services.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");


Console.WriteLine("Provide subscriptionid: ");
var subscriptionId = Console.ReadLine();

using (var bus = RabbitHutch.CreateBus("host=localhost"))
{
    bus.PubSub.Subscribe<Platum>("test", HandleTextMessage);
    Console.WriteLine("Listening for messages. Hit <return> to quit.");
    Console.ReadLine();
}

void HandleTextMessage(Platum entity)
{
    Console.WriteLine($"Received: {entity?.PlataId}, {entity?.DatumSlanja}, {entity?.Iznos}");
}