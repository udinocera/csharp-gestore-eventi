using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        public Evento(string titolo, DateTime dataEvento, int postiDisponibili)
        {
            this.titolo = titolo;
            data = dataEvento;
            capienzaMassima = postiDisponibili;
            postiPrenotati = 0;
        }

        public string getTitolo()
        {
            return titolo;
        }

        public DateTime getDataEvento()
        {
            return data;
        }

        public int getPostiPrenotati()
        {
            return postiPrenotati;
        }

        public int getCapienzaMassima()
        {
            return capienzaMassima;
        }

        public void setTitolo(string titolo)
        {
            if (string.IsNullOrEmpty(titolo))
                this.titolo = titolo;
            else
                throw new ArgumentException("Non hai inserito un titolo corretto");
        }

        public void setData(DateTime dataEvento)
        {
            if (dataEvento > DateTime.Now)
                this.data = dataEvento;
            else
                throw new ArgumentException("Hai inserito una data passata");
        }

        public void prenotare(int postiRichiesti)
        {
            if (data > DateTime.Now)
            {
                if (postiDisponibili() > 0)
                {
                    if (postiRichiesti < capienzaMassima)
                    {
                        if (postiRichiesti < postiDisponibili())
                            postiPrenotati += postiRichiesti;
                        else
                            throw new Exception("Inserisci meno posti");
                    }
                }
                else
                {
                    throw new Exception("Posti Finiti");
                }
            }
            else
                throw new Exception("L'evento è finito");
        }

        public void disdire(int PostiRichiesti)
        {
            if (data > DateTime.Now)
            {
                if (PostiRichiesti < capienzaMassima)
                {
                    if (PostiRichiesti < postiPrenotati)
                        postiPrenotati -= PostiRichiesti;
                    else
                        throw new Exception("Vuoi disdire più posti di quelli che hai");
                }
                else
                    throw new Exception("Chiedi meno posti");
            }
            else
                throw new Exception("L'evento è già finito");
        }

        public int postiDisponibili()
        {
            return capienzaMassima - postiPrenotati;
        }

        public string stampaDataTitolo()
        {
            return getDataEvento() + "-" + getTitolo() + "\n";
        }

        public override string ToString()
        {
            return "\nEvento: " + "\nTitolo: " + titolo +
                    "\nData: " + data.ToString("dd/MM/yyyy") +
                    "\nCapienza massima evento: " + capienzaMassima +
                    "\nPosti prenotati: " + postiPrenotati;
        }
    }
}




            
