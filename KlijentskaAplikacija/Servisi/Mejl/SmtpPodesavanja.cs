namespace KlijentskaAplikacija.Servisi.Mejl
{
    public static class SmtpPodesavanja
    {
        public static string Host = "smtp.gmail.com"; // izmeni po potrebi
        public static int Port = 587; // 465 (SSL) ili 587 (STARTTLS)
        public static bool Ssl = true;
        public static string Korisnik = "danicaadjurdjic@gmail.com"; // npr. email ili app password korisnik
        public static string Lozinka = "zexifizrilxxdbgs"; // lozinka ili app password
        public static string Posiljalac = "danicaadjurdjic@gmail.com"; // email adresa po�iljaoca
    }
}


