﻿using Discord;
using Discord.WebSocket;

namespace Alojzy
{
    internal class Program
    {
        private DiscordSocketClient? _client;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += Handler.CommandHandler;
            _client.Log += Log;
            var token = File.ReadAllText("C:/xyz.txt");

            //var token = "";
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

    }
}