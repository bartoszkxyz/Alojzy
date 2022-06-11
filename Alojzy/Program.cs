using Discord;
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
            _client.MessageReceived += CommandHandler;
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

        public Task CommandHandler(SocketMessage msg)
        {
            string cmd = msg.Content.Substring(1, msg.Content.Length - 1).ToLower();

            //Filtering
            if (!msg.Author.IsBot)
            {
                //
                if (!msg.Content.StartsWith('.')) return Task.CompletedTask;
                //
                if (cmd == "hello") msg.Channel.SendMessageAsync($"Hi {msg.Author.Mention}");
                //
                if (cmd.StartsWith("roll"))
                {
                    var Numery = Roll(msg.ToString());
                    msg.Channel.SendMessageAsync($"**result:** {msg.ToString().Substring(5)} ({Numery}");
                }
                else
                {
                    msg.Channel.SendMessageAsync("lol");
                }
            }
            else return Task.CompletedTask;

            return Task.CompletedTask;
        }

        static string Roll(string cmd)
        {
            string text = "";
            var Random = new Random();
            List<int> Numery = new List<int>();
            int diceNumber = int.Parse(cmd[5..cmd.IndexOf('d')].ToString()), diceSize = int.Parse(cmd[(cmd.IndexOf('d') + 1)..^0].ToString()), total = 0;

            //
            for (int i = 1; i <= diceNumber; i++)
            {
                var numer = Random.Next(1, diceSize + 1);
                Numery.Add(numer);
                if (!(i == diceNumber))
                    text += numer.ToString() + ", ";
                else
                    text += numer.ToString() + ")";
                total += numer;
            }
            text += $"\n**total: ** {total}";

            return text;
        }
    }
}