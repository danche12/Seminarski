using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    public enum Operacija
    {
        Ping,
        Login,
        VratiPrebivalista,
        ZapamtiPolaznika,
        ZapamtiInstruktora,
        ZapamtiCas,
        PretraziPolaznika,
        AzurirajPolaznika,
        ObrisiPolaznika,
        PretraziInstruktora,
        VratiInstruktore,
        PretraziCas,
        VratiCasove,
        VratiPolaznike,
        Logout,
        ZapamtiEvidencijuKursa,
        VratiEvidencijeKursa,
        PretraziEvidencijuKursa,
        UcitajEvidencijuKursa,
        VratiSertifikate,
        UbaciInstruktorSertifikat,
        VratiInstruktorSertifikate,
        AzurirajEvidenciju,
        UbaciSertifikat,
    }
}
