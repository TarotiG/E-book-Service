using System;
using System.Collections.Generic;
using System.Net.Mail;


class EBookService
{
    public static void Main(string[] args)
    {
        EbookHandler handler = new EbookHandler();
        // Bekijk folder voor nieuwe boeken - VERDER UITWERKEN
        List<string> nieuweBoeken = handler.boekenNietVerstuurd();
        foreach (string boek in nieuweBoeken)
        {
            Console.WriteLine($"[INFO] - {boek} is nieuw.");
        }

        // Valideer boek bestandsextensie en sorteer
        handler.valideerBoekenExtensie();

        // Boek kiezen omn te versturen - UITWERKEN
        Attachment voorbeeldBoek = new Attachment("Verhuurderverklaring Tyron - getekend (1).pdf");
        Attachment voorbeeldBoek2 = new Attachment("test_data9.csv");

        // Client opzetten en verstuur een boek naar e-reader
        try
        {
            EmailClient service = new EmailClient(
            "smtp.gmail.com",
            587,
            "tyronlsg@gmail.com",
            "tyronlsg@pbsync.com",
            voorbeeldBoek
            );

            service.verstuurEmail();   
        }
        catch(NotImplementedException)
        {
            Console.WriteLine("Nog niet afgerond");
        }

        // Verplaats verstuurde boek naar [verstuurd]
        handler.verplaatsVerstuurdeBoek(voorbeeldBoek.Name);
    }
}
