using System;
using App.EventHandler.Support;
using App.Common.Mail;
using App.Common.DI;
using App.Common.Event;

namespace App.EventHandler.Impl.Support
{
    internal class SupportRequestEventHandler : BaseEventHandler<SupportRequestOnStatusChanged>, ISupportRequestEventHandler
    {
        public override void Execute(SupportRequestOnStatusChanged ev)
        {
            SupportRequestOnStatusChangedMailContent mailContent = new SupportRequestOnStatusChangedMailContent(ev);
            IMailService mailService = IoC.Container.Resolve<IMailService>();
            mailService.Send(mailContent);
        }
    }
}
