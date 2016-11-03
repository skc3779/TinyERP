using System;
using App.EventHandler.Support;
using App.Common.Mail;
using App.Common.DI;

namespace App.EventHandler.Impl.Support
{
    internal class SupportRequestEventHandler : ISupportRequestEventHandler
    {
        public void Execute(SupportRequestOnStatusChanged ev)
        {
            SupportRequestOnStatusChangedMailContent mailContent = new SupportRequestOnStatusChangedMailContent(ev);
            IMailService mailService = IoC.Container.Resolve<IMailService>();
            mailService.Send(mailContent);
        }
    }
}
