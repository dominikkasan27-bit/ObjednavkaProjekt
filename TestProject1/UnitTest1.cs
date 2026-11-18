using ObjednavkaProjekt.Třídy;

namespace TestProject1
{
    public class ObjednavkaTests
    {
        [Theory]
        [InlineData(1499.99, 99)]
        [InlineData(1500, 0)]
        [InlineData(2000, 0)]
        public void VypocitejDopravu_PriOsobnimOdbereVratiSpravnouCenu(
            decimal cenaZbozi,
            decimal ocekavanaDoprava)
        {
            var objednavka = new Objednavka(cenaZbozi, 0);

            decimal doprava = objednavka.VypocitejDopravu();

            Assert.Equal(ocekavanaDoprava, doprava);
        }

        [Fact]
        public void VypocitejDopravu_PriKuryrnistransportuVrati199()
        {
            var objednavka = new Objednavka(500, 1);

            decimal doprava = objednavka.VypocitejDopravu();

            Assert.Equal(199, doprava);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        [InlineData(99)]
        public void VypocitejDopravu_PriNeznamemTypuVratiNulu(int typDopravy)
        {
            var objednavka = new Objednavka(500, typDopravy);

            decimal doprava = objednavka.VypocitejDopravu();

            Assert.Equal(0, doprava);
        }

        [Theory]
        [InlineData(1000, 0, 1099)]
        [InlineData(1500, 0, 1500)]
        [InlineData(1000, 1, 1199)]
        [InlineData(1000, 2, 1000)]
        public void VypocitejCelkem_VratiCenuZboziVCenouDopravy(
            decimal cenaZbozi,
            int typDopravy,
            decimal ocekavanaCena)
        {
            var objednavka = new Objednavka(cenaZbozi, typDopravy);

            decimal celkem = objednavka.VypocitejCelkem();

            Assert.Equal(ocekavanaCena, celkem);
        }

        [Fact]
        public void Konstruktor_NastaviVlastnostiObjednavky()
        {
            var objednavka = new Objednavka(1234.56m, 1);

            Assert.Equal(1234.56m, objednavka.CenaZbozi);
            Assert.Equal(1, objednavka.TypDopravy);
        }
    }
}
