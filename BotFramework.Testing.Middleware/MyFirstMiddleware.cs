using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Middleware;
using Microsoft.Bot.Schema;

namespace BotFramework.Testing.Middleware
{
    public class MyFirstMiddleware : IReceiveActivity, ISendActivity, IContextCreated
    {
        public MyFirstMiddleware()
        {
        }

        public async Task ContextCreated(IBotContext context, MiddlewareSet.NextDelegate next)
        {
            context.Reply("ContextCreated");
            await next().ConfigureAwait(false);
        }

        public async Task ReceiveActivity(IBotContext context, MiddlewareSet.NextDelegate next)
        {
            context.Reply("ReceiveActivity");
            await next().ConfigureAwait(false);
        }

        public async Task SendActivity(IBotContext context, IList<Activity> activities, MiddlewareSet.NextDelegate next)
        {
            context.Reply("SendActivity");
            await next().ConfigureAwait(false);
        }
    }
}
