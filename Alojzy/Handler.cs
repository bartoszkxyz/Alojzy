using Alojzy.Modules;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojzy
{
    internal class Handler
    {
        public static Task CommandHandler(SocketMessage msg)
        {
            //Filtering
            if (!msg.Author.IsBot)
            {
                //
                if (!msg.Content.StartsWith('.')) return Task.CompletedTask;
                else
                {
                    string cmd = msg.Content.Substring(1, msg.Content.Length - 1).ToLower();
                                    //
                    if (cmd == "hello") msg.Channel.SendMessageAsync($"Hi {msg.Author.Mention}");
                    //
                    else if (cmd.StartsWith("roll"))
                    {
                        var text = Commands.Roll(msg.ToString());
                        msg.Channel.SendMessageAsync($"{msg.Author.Mention} \n**Result:** {msg.ToString().Substring(5)} {text}");
                    }
                    else if (cmd.StartsWith("bnb"))
                    {
                        msg.Channel.SendMessageAsync(Commands.BNB());
                    }
                    //
                    else
                    {
                        msg.Channel.SendMessageAsync("lol");
                    }
                }
            }
            else return Task.CompletedTask;

        return Task.CompletedTask;
        }
    }
}
