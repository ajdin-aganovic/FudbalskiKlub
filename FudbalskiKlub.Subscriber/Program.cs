// See https://aka.ms/new-console-template for more information
using EasyNetQ;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Services.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

var bus = RabbitHutch.CreateBus("host=localhost:15672;username=guest;password=guest");
var bus1 = RabbitHutch.CreateBus("host=localhost:15672;username=guest;password=guest");
await bus.PubSub.SubscribeAsync<ProizvodActivated>("console_print", msg =>
{
    if(msg!=null)
    {
        if(msg.ProizvodPoruka.StateMachine.Contains("active"))
            Console.WriteLine($"Proizvod aktiviran: {msg.ProizvodPoruka.Naziv}");
        else
        {
            Console.WriteLine($"Proizvod deaktiviran: {msg.ProizvodPoruka.Naziv}");
        }
    }
    else
    {
        Console.WriteLine("Pogresan proizvod");
    }

});

await bus1.PubSub.SubscribeAsync<PlatumActivated>("console_print", msg =>
{
    if (msg != null)
    {
        if (msg.PlatumPoruka.StateMachine.Contains("active"))
            Console.WriteLine($"Plata aktivirana: {msg.PlatumPoruka.Iznos}");
        else
        {
            Console.WriteLine($"Plata deaktivirana: {msg.PlatumPoruka.Iznos}");
        }

    }
    else
    {
        Console.WriteLine("Pogresna plata");
    }

});


Console.WriteLine("Listening to messages, press Return to close!");
Console.ReadLine();
