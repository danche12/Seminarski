using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ServerskaAplikacija
{
    public class ClientHandler
    {
        private Socket klijentskiSoket;
        private JsonNetworkSerializer jns;
        bool kraj = false;
        private List<ClientHandler> prijavljeniKorisnici;

        public ClientHandler(Socket klijent, List<ClientHandler> prijavljeniKorisnici)
        {
            klijentskiSoket = klijent;
            this.prijavljeniKorisnici = prijavljeniKorisnici;
            jns = new JsonNetworkSerializer(klijentskiSoket);
        }

        public void HandleRequest()
        {
            try
            {
                while (!kraj)
                {
                    Zahtev zahtev = jns.PrimiPoruku<Zahtev>();

                    Odgovor odgovor = new Odgovor();
                    odgovor.IsSuccessful = true;

                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            Instruktor i = jns.ReadType<Instruktor>(zahtev.Podatak);
                            odgovor.Podatak = Kontroler.Instance.Prijava(i);
                            if (i != null)
                            {
                                odgovor.IsSuccessful = true;
                            }
                            else
                            {
                                odgovor.IsSuccessful = false;
                            }

                            break;

                        case Operacija.ZapamtiPolaznika:
                            Polaznik p = jns.ReadType<Polaznik>(zahtev.Podatak);
                            Kontroler.Instance.ZapamtiPolaznika(p);
                            break;

                        case Operacija.PretraziPolaznika:
                            string[] imeiprezime = jns.ReadType<string[]>(zahtev.Podatak);
                            List<Polaznik> polaznik = Kontroler.Instance.PretraziPolaznika(imeiprezime);
                            odgovor.Podatak = polaznik;
                            break;
                        case Operacija.ObrisiPolaznika:
                            p = jns.ReadType<Polaznik>(zahtev.Podatak);
                            int obj = Kontroler.Instance.ObrisiPolaznika(p);
                            if (obj == 0)
                                odgovor.IsSuccessful = false;
                            else
                                odgovor.IsSuccessful = true;

                            break;


                        case Operacija.VratiPrebivalista:
                            List<Prebivaliste> prebivalista = jns.ReadType<List<Prebivaliste>>(zahtev.Podatak);
                            prebivalista = Kontroler.Instance.VratiPrebivalista();
                            odgovor.Podatak = prebivalista;
                            break;

                        case Operacija.ZapamtiCas:
                            Cas cas = jns.ReadType<Cas>(zahtev.Podatak);
                            Kontroler.Instance.ZapamtiCas(cas);
                            break;

                        case Operacija.ZapamtiInstruktora:
                            Instruktor instruktor = jns.ReadType<Instruktor>(zahtev.Podatak);
                            Kontroler.Instance.ZapamtiInstruktora(instruktor);
                            break;

                        case Operacija.VratiPolaznike:
                            List<Polaznik> polaznici = jns.ReadType<List<Polaznik>>(zahtev.Podatak);
                            polaznici = Kontroler.Instance.VratiPolaznike();
                            odgovor.Podatak = polaznici;
                            break;

                        case Operacija.VratiCasove:
                            List<Cas> casovi = Kontroler.Instance.VratiCasove();
                            odgovor.Podatak = casovi;
                            break;

                        case Operacija.VratiInstruktore:
                            List<Instruktor> instruktori= jns.ReadType<List<Instruktor>>(zahtev.Podatak);
                            instruktori = Kontroler.Instance.VratiInstruktore();
                            odgovor.Podatak = instruktori;
                            break;

                        case Operacija.ZapamtiEvidencijuKursa:
                            EvidencijaKursa evidencijaKursa = jns.ReadType<EvidencijaKursa>(zahtev.Podatak);
                            int rez = (int)Kontroler.Instance.ZapamtiEvidenciju(evidencijaKursa);
                            if (rez == 0)// nije uspeo da zapamti ugovor
                            {
                                odgovor.IsSuccessful = false;
                            }

                            break;

                        case Operacija.VratiEvidencijeKursa:
                            List<EvidencijaKursa> evidencije = jns.ReadType<List<EvidencijaKursa>>(zahtev.Podatak);
                            evidencije = Kontroler.Instance.vratiEvidencije();
                            odgovor.Podatak = evidencije;
                            break;

                        case Operacija.PretraziEvidencijuKursa:
                            evidencijaKursa = jns.ReadType<EvidencijaKursa>(zahtev.Podatak);

                            List<EvidencijaKursa> evidencijePoKriterijumu = Kontroler.Instance.PretraziEvidenciju(evidencijaKursa);
                            if (evidencijePoKriterijumu.Count > 0)
                            {
                                odgovor.Podatak = evidencijePoKriterijumu;

                            }
                            else
                            {
                                odgovor.IsSuccessful = false;
                                odgovor.Podatak = null;

                            }

                            break;

                        case Operacija.UbaciInstruktorSertifikat:
                            InstruktorSertifikat ins = jns.ReadType<InstruktorSertifikat>(zahtev.Podatak);
                            try
                            {
                                Kontroler.Instance.UbaciInstruktorSertifikat(ins);
                                odgovor.IsSuccessful = true;
                            }
                            catch (Exception)
                            {
                                odgovor.IsSuccessful = false;
                            }
                            break;
                        case Operacija.UbaciSertifikat:
                            Sertifikat s = jns.ReadType<Sertifikat>(zahtev.Podatak);
                            try
                            {
                                Kontroler.Instance.UbaciSertifikat(s);
                                odgovor.IsSuccessful = true;
                            }
                            catch (Exception)
                            {
                                odgovor.IsSuccessful = false;
                            }
                            break;

                        case Operacija.VratiInstruktorSertifikate:
                            List<InstruktorSertifikat> inssertifikati = Kontroler.Instance.VratiInstruktorSertifikate();
                            odgovor.Podatak = inssertifikati;
                            break;

                        case Operacija.VratiSertifikate:
                            List<Sertifikat> sertifikati = Kontroler.Instance.VratiSertifikate();
                            odgovor.Podatak = sertifikati;
                            break;
                        case Operacija.AzurirajPolaznika:
                            Polaznik pol = jns.ReadType<Polaznik>(zahtev.Podatak);
                            Kontroler.Instance.AzurirajPolaznika(pol);
                            break;
                        case Operacija.PretraziInstruktora:
                            Instruktor instr = jns.ReadType<Instruktor>(zahtev.Podatak);
                            odgovor.Podatak = Kontroler.Instance.PretraziInstruktora(instr);
                            break;
                        case Operacija.AzurirajEvidenciju:
                            EvidencijaKursa e = jns.ReadType<EvidencijaKursa>(zahtev.Podatak);
                            long azurirano = Kontroler.Instance.AzurirajEvidencijuKursa(e);
                            if (azurirano == 0)
                            {
                                odgovor.IsSuccessful = false;
                            }

                            break;
                        case Operacija.PretraziCas:
                            cas = jns.ReadType<Cas>(zahtev.Podatak);
                            odgovor.Podatak = Kontroler.Instance.PretraziCas(cas);
                            break;
                        case Operacija.UcitajEvidencijuKursa:
                            evidencijaKursa = jns.ReadType<EvidencijaKursa>(zahtev.Podatak);
                            EvidencijaKursa popunjenaEvidencija = Kontroler.Instance.ucitajUgovor(evidencijaKursa);
                            // Uvek vrati popunjenu evidenciju, čak i ako nema stavki
                            odgovor.Podatak = popunjenaEvidencija;
                            odgovor.IsSuccessful = true;
                            break;
                        case Operacija.Logout:
                            Logout();
                            break;
                        case Operacija.Ping:
                            odgovor.Podatak = true;      // samo potvrda
                            odgovor.IsSuccessful = true;
                            break;
                        default:
                            break;


                    }
                    jns.PosaljiPoruku(odgovor);
                }
            }
            catch (IOException ex)
            {
                Stop();
            }
            catch (SocketException s)
            {
                Stop();
            }
            finally
            {
                Stop();
            }
        }

        public void Stop()
        {
            kraj = true;
            try { klijentskiSoket?.Shutdown(SocketShutdown.Both); } catch { }
            try { klijentskiSoket?.Close(); } catch { }
        }

        public void Logout()
        {
            kraj = true;

            try { prijavljeniKorisnici?.Remove(this); } catch { }
            try { klijentskiSoket?.Shutdown(SocketShutdown.Both); } catch { }
            try { klijentskiSoket?.Close(); } catch { }
        }
    }
}