using System;
using System.IO;
using System.Collections.Generic;

class EbookHandler
{
    string pathBoeken = "C:\\Users\\tyron\\OneDrive\\Bureaublad\\E-book Service\\boeken";
    string pathBoekenNietMogelijk = "C:\\Users\\tyron\\OneDrive\\Bureaublad\\E-book Service\\boeken\\niet mogelijk";

    public List<string> boekenNietVerstuurd()
    {
        List<string> boeken = new List<string>();
        var bestanden = Directory.EnumerateFiles(this.pathBoeken, "*.epub", SearchOption.AllDirectories);

        foreach (string boek in bestanden)
        {
            if(File.Exists(this.pathBoeken))
            {
                boeken.Add(boek);
            }
        }
        return boeken;
    }

    public void valideerBoekenExtensie()
    {
        List<string> boekenNietMogelijk = new List<string>();
        var bestanden = Directory.EnumerateFiles(this.pathBoeken, "*", SearchOption.AllDirectories);

        foreach (string boek in bestanden)
        {
            if (boek.Contains(".epub") || boek.Contains(".mobi") || boek.Contains(".pdf"))
            {
                Console.WriteLine($"Boek: {boek} kan verstuurd worden");
            }
            else
            {
                boekenNietMogelijk.Add(boek);
                Directory.Move($"{this.pathBoeken}\\{boek}", this.pathBoekenNietMogelijk);
                Console.WriteLine($"'{boek}' heeft geen ondersteunde bestandsextensie. Het is verplaatst naar het mapje 'niet mogelijk'");
            }
        }
    }

    // Method -> Boek bestand verplaatsen naar "verstuurd"
}