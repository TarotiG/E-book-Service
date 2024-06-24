using System;
using System.Net.Http.Headers;
using System.Net.Mail;

class EmailClient
{
    private SmtpClient client;
    private MailMessage message;

    EmailClient(string host, int port, string vanEmailAdres, string naarEmailAdres, string boekBestand)
    {
        this.client = new SmtpClient(host, port);
        this.message = new MailMessage(vanEmailAdres, naarEmailAdres);
        setBestandInMail(boekBestand);
    }

    void setEmailInhoud()
    {
        message.Subject = "";
        message.Body = "";
    }

    void setBestandInMail(string boekBestand)
    {
        Attachment bestand = new Attachment(boekBestand);
        this.message.Attachments.Add(bestand);
    }
}