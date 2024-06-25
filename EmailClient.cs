using System;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;

public class EmailClient
{
    public SmtpClient client;
    public MailMessage message;
    public Attachment boekBestand;

    public EmailClient(string host, int port, string vanEmailAdres, string naarEmailAdres, Attachment bestand)
    {
        this.client = new SmtpClient(host, port);
        this.message = new MailMessage(vanEmailAdres, naarEmailAdres);
        this.boekBestand = new Attachment(bestand.Name);
    }

    public void setEmailInhoud()
    {
        this.message.Attachments.Add(this.boekBestand);

        this.message.Subject = this.boekBestand.Name;
        this.message.Body = $"{this.boekBestand.Name} verstuurd met E-Book Service!";
    }

    public void verstuurEmail()
    {
        setEmailInhoud();
        this.client.Send(this.message);
    }
}