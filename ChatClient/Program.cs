using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ChatClient
{
    class Program
    {
        private static HubConnection _hubConnection;
        private static bool isConnected;
        private static string senderID;
        private static string recipientID;
        private static string contents;

        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {

            System.Console.WriteLine("Type your name:");

            senderID = System.Console.ReadLine();

            await SetupSignalRHubAsync();

            do
            {
                try
                {
                    if (!isConnected)
                    {
                        await SetupSignalRHubAsync();
                    }
                    else
                    {
                        var message = System.Console.ReadLine();

                        if (!string.IsNullOrEmpty(message))
                        {
                            await _hubConnection.SendAsync("SendMessage",  "Khaled" , "Tuhser" , "Hi" );
                            System.Console.WriteLine("SendAsync to Hub");
                        }
                    }
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    System.Console.WriteLine($"Error on SendAsync: {ex.Message}");
                }
            }
            while (System.Console.ReadKey(false).Key != ConsoleKey.Escape);

            await _hubConnection.DisposeAsync();
        }

        private static async Task SetupSignalRHubAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:36383/chathub")
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole();
                    factory.AddFilter("Console", level => level >= LogLevel.Trace);
                }).Build();

            await _hubConnection.StartAsync();

            System.Console.WriteLine("Connected to Hub");
            System.Console.WriteLine("Press ESC to stop");
            System.Console.WriteLine("Type message:");

            isConnected = true;

            try
            {
                await _hubConnection.SendAsync("OnUserConnected", "Tusher");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error on OnUserConnected: {ex.Message}");
                isConnected = false;
            }

            _hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(3);

            _hubConnection.Closed += (args) =>
            {
                isConnected = false;
                System.Console.WriteLine($"Connection close {args?.Message}");
                return Task.CompletedTask;
            };

            _hubConnection.On<Message>("ReceiveMessage", (message) =>
            {
                if (message != null)
                {
                    System.Console.WriteLine($"Received Message -> {message.senderID} said: {message.contents}");
                }
            });

            _hubConnection.On<Message>("UserConnected", (message) =>
            {
                System.Console.WriteLine($"{message.contents}");
            });

            _hubConnection.On<Message>("UserDisconnected", (message) =>
            {
                System.Console.WriteLine($"{message.contents}");
            });
        }
    }
}

