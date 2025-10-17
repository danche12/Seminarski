using Common.Domen;
using ServerskaAplikacija.Repozitorijum;
using System;

namespace ServerskaAplikacija.SistemskeOperacije
{
    public abstract class SistemskaOperacijaBaza
    {
        protected IDBRepozitorijum<IEntitet> repozitorijum;

        public SistemskaOperacijaBaza()
        {
            repozitorijum = new GenerickiRepo();
        }

        public void ExecuteTemplate()
        {
            try
            {
                zapocniTransakciju();
                Izvrsi();
                potvrdiTransakciju();
            }
            catch (Exception)
            {
                ponistiTransakciju();
                throw;
            }
            finally
            {
                zatvoriKonekciju();
            }
        }

        private void zatvoriKonekciju()
        {
            repozitorijum.Close();
        }

        private void ponistiTransakciju()
        {

            repozitorijum.Rollback();
        }

        private void potvrdiTransakciju()
        {
            repozitorijum.Commit();
        }

        private void zapocniTransakciju()
        {
            repozitorijum.Open();
        }

        protected abstract void Izvrsi();


    }
}
