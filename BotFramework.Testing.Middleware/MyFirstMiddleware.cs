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
        private Guid instanceId;

        public MyFirstMiddleware()
        {
            this.instanceId = Guid.NewGuid();
        }

        public async Task ContextCreated(IBotContext context, MiddlewareSet.NextDelegate next)
        {
            context.Reply($"{instanceId}:ContextCreated");
            await next().ConfigureAwait(false);
        }

        public async Task ReceiveActivity(IBotContext context, MiddlewareSet.NextDelegate next)
        {
            context.Reply($"{instanceId}:ReceiveActivity");
            await next().ConfigureAwait(false);
        }

        public async Task SendActivity(IBotContext context, IList<Activity> activities, MiddlewareSet.NextDelegate next)
        {
            context.Reply($"{instanceId}:SendActivity");
            await next().ConfigureAwait(false);
        }
    }
}
