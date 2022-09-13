using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    // to jest klasa która zamiast kluczy obcych pozwoli na wyświetlanie konkrentych danych
    class LokalForAllView
    {
        public int IdLokaluWspolnoty { get; set; }
        public string WspolnotaNazwa { get; set; }
        public string BudynekMiasto { get; set; }
        public string BudynekUlica { get; set; }
        //To jest pole zamiast IdBudynku
        public string BudynekNumer { get; set; }
        //To jest pole zamiast IdRodzajuLokalu
        public string WlascicielImie { get; set; }
        public string WlascicielNazwisko { get; set; }
        public string LokalKlatka { get; set; }
        public string LokalNumer { get; set; }
        public decimal? LokalPowierzchnia { get; set; }
        public decimal? LokalUdzial { get; set; }
        public string JednostkaMiarySymbol { get; set; }
        //to jest pole zamiast IdJednostki
    }
}
