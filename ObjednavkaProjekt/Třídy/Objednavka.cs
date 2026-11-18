using System;
using System.Collections.Generic;
using System.Text;

namespace ObjednavkaProjekt.Třídy
{
    public class Objednavka
    {
        public decimal CenaZbozi { get; set; }
        public int TypDopravy { get; set; }

        public Objednavka(decimal cenaZbozi, int typDopravy)
        {
            CenaZbozi = cenaZbozi;
            TypDopravy = typDopravy;
        }

        public decimal VypocitejDopravu()
        {
            if (TypDopravy == 0)
            {
                if (CenaZbozi >= 1500)
                {
                    return 0;
                }

                return 99;
            }
            else if (TypDopravy == 1)
            {
                return 199;
            }
            else
            {
                return 0;
            }
        }

        public decimal VypocitejCelkem()
        {
            return CenaZbozi + VypocitejDopravu();
        }
    }
}
