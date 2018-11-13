namespace SportsStore.Domain.Concrete
{
    using System;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using System.Net.Mail;
    using System.Net;
    using System.Text;

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings settings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            this.settings = settings;
        }
        public void ProcessorOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = settings.UseSsl;
                smtpClient.Host = settings.ServerName;
                smtpClient.Port = settings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(settings.Username, settings.Password);
                if (settings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = settings.FileLocation; smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---").AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(settings.MailFromAddress, settings.MailToAddress, "New order submitted!", body.ToString());                // Body                if (emailSettings.WriteAsFile) {                    mailMessage.BodyEncoding = Encoding.ASCII;                }                smtpClient.Send(mailMessage);


                if (settings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}
