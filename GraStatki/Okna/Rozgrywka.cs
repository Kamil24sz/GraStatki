using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraStatki.Klasy;

namespace GraStatki
{
    public partial class Rozgrywka : Form
    {
        // współrzędne myszy
        int myszX;
        int myszY;

        public Rozgrywka()
        {
            InitializeComponent();

            //początkowe wartości
            myszX = -1;
            myszY = -1;
        }

        private void planszaGracza_Rysowanie(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.gracz.Plansza, e);
            Rysowanie.RysujKomorki(Gra.gracz.OdkrytePola, Gra.gracz.Plansza, e);
        }

        private void planszaKomputera_Rysowanie(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujZatopioneStatki(Gra.komputer.Plansza, Gra.komputer.Flota, e);
            Rysowanie.RysujKomorki(Gra.komputer.OdkrytePola, Gra.komputer.Plansza, e);
        }

        private void planszaKomputera_PoruszanieMysza(object sender, MouseEventArgs e)
        {
            if (Koordynaty.PobierzX(this, planszaKomputera) != -1 && Koordynaty.PobierzY(this, planszaKomputera) != -1)
            {
                //pobieramy koordynaty kursora (na planszy gracza)
                myszX = Koordynaty.PobierzKomorke(Koordynaty.PobierzX(this, planszaKomputera));
                myszY = Koordynaty.PobierzKomorke(Koordynaty.PobierzY(this, planszaKomputera));

                planszaKomputera.Refresh();

                Rysowanie.RysujObramowanie(myszX, myszY, 4, planszaKomputera);
            }
            else
            {
                myszX = -1;
                myszY = -1;

                planszaKomputera.Refresh();
            }
        }

        private void planszaKomputera_Klikniecie(object sender, EventArgs e)
        {
            //sprawdzamy czy kursor jest w obrębie planszy
            if(myszX != -1 && myszY != -1)
            {
                //sprawdzamy czy komórka nie byłą wcześniej kliknięta
                if (!Gra.komputer.OdkrytePola[myszX, myszY])
                {
                    //true jeśli został trafiony statek
                    if(Gra.WykonajAtak(myszX, myszY, Gra.gracz, Gra.komputer))
                    {
                        planszaKomputera.Refresh();
                        //w przecuwnym razie ( nie trafiony) ruch komputera
                    }
                    else
                    {
                        planszaKomputera.Refresh();

                        //wybieramy pole do ruchu komputera
                        int[] ruchKomputera = Gra.StrzalKomputera(Gra.gracz);

                        //dopóki komputer trafia to jego tura trwa dalej
                        while(Gra.WykonajAtak(ruchKomputera[0], ruchKomputera[1], Gra.komputer, Gra.gracz))
                        {
                            ruchKomputera = Gra.StrzalKomputera(Gra.gracz);
                            planszaGracza.Refresh();
                        }
                        //odświeżenie planszy
                        planszaGracza.Refresh();
                    }
                }
            }
        }
    }
}
