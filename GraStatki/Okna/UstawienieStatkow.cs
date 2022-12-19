using GraStatki.Klasy;
using System;
using System.Windows.Forms;

namespace GraStatki
{
    public partial class UstawienieStatkow : Form
    {
        //stała którą będziemy porównywać do stanu w którym kursor jest poza planszą
        const int POZA_PLANSZA = -1;

        // współrzędne myszy
        int myszX;
        int myszY;

        //indeks do tablicy z długościami statków
        int indexAktualnegoStatku;

        //informacja czy statek będzie układany poziomo czy pionowo
        //true = poziomo
        //flase = pionowo
        bool poziom;

        bool[] rozmieszczoneStatki = new bool[4];

        bool kursonNaPlanszy;

        //index ostatniego pola planszy
        int OSATNI_INDEX_PLANSZY = Gracz.ROZMIAR_PLANSZY - 1;

        public UstawienieStatkow()
        {
            InitializeComponent();

            //statki domyślnie ukłądane są poziomo
            poziom = true;

            //tworzenie obiektów graczy
            Klasy.Gra.gracz = new Gracz();
            Klasy.Gra.komputer = new Gracz();

            indexAktualnegoStatku = 0;
            btnDalej.Enabled = false;
        }

        private void PlanszaGracza_PoruszanieMysza(object sender, MouseEventArgs e)
        {
            //sprawdzamy który statek będzie aktualnie rysowany
            if(indexAktualnegoStatku < 4)
            {
                //sprawdzamy czy kursor znajduję się w planszy (dla X i Y)
                kursonNaPlanszy = Koordynaty.PobierzKomorke(Koordynaty.PobierzX(this, planszaGracza)) != POZA_PLANSZA &&
                    Koordynaty.PobierzKomorke(Koordynaty.PobierzY(this, planszaGracza)) != POZA_PLANSZA;

                if (kursonNaPlanszy)
                {
                    //pobieramy koordynaty komórki
                    myszX = Koordynaty.PobierzKomorke(Koordynaty.PobierzX(this, planszaGracza));
                    myszY = Koordynaty.PobierzKomorke(Koordynaty.PobierzY(this, planszaGracza));

                    //odświeżenie planszy
                    planszaGracza.Refresh();

                    //jeśli true to statek jest poziomo
                    if (poziom)
                    {
                        for(int i = 0; i < Klasy.Gra.rozmiarStatku[indexAktualnegoStatku]; i++)
                        {
                            if (myszX + i <= OSATNI_INDEX_PLANSZY)
                                Klasy.Rysowanie.RysujObramowanie(myszX + i, myszY, indexAktualnegoStatku, planszaGracza);
                            else
                                break;
                        }
                    }
                    // poziom == false, to statek rysujemy pionowo
                    else
                    {
                        for (int i = 0; i < Klasy.Gra.rozmiarStatku[indexAktualnegoStatku]; i++)
                        {
                            if (myszY + i <= OSATNI_INDEX_PLANSZY)
                                Klasy.Rysowanie.RysujObramowanie(myszX, myszY + i, indexAktualnegoStatku, planszaGracza);
                            else
                                break;
                        }
                    }
                }
            }
            else
            {
                if(myszX != POZA_PLANSZA || myszY != POZA_PLANSZA)
                {
                    myszX = POZA_PLANSZA;
                    myszY = POZA_PLANSZA;
                    planszaGracza.Refresh();
                }
            }
        }

        private void planszaGracza_Click(object sender, EventArgs e)
        {
            //sprawdzamy czy współrzędne myszy nie są poza planszą
            if(myszX != -1 && myszY != -1)
            {
                //sprawdzamy czy statek nie wyjdzie poza planszę
                if (Gra.MoznaPostawicSatek(indexAktualnegoStatku, myszX, myszY, poziom, Gra.gracz.Plansza))
                {
                    // jeśli można postawić dany dtatek to ustawiamy index tablcy na true
                    rozmieszczoneStatki[indexAktualnegoStatku] = true;

                    //Umieszczenie statku na planszy
                    Gra.RozmiescStatek(indexAktualnegoStatku, myszX, myszY, poziom, Gra.gracz.Plansza);

                    //odświeżamy plansze
                    planszaGracza.Refresh();

                    if (indexAktualnegoStatku < 4)
                    {
                        indexAktualnegoStatku++;
                    }

                    //zmienna pomocnicza do sprawdzenia czy wszystkie statki są rozmieszczone
                    bool wszystkieStatkiRozmieszczone = true;

                    //sprawdzenie czy wszystkie statki są rozmieszczone
                    foreach (bool rozmieszczony in rozmieszczoneStatki)
                    {
                        if (!rozmieszczony)
                        {
                            wszystkieStatkiRozmieszczone = false;
                        }
                    }

                    if (wszystkieStatkiRozmieszczone)
                    {
                        btnDalej.Enabled = true;
                    }

                } 
            }
        }

        private void PlanszaGracza_Rysowanie(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.gracz.Plansza, e);
        }

        private void btnObrot_Click(object sender, EventArgs e)
        {
            poziom = !poziom;
        }

        private void btnDalej_Click(object sender, EventArgs e)
        {
            if(txtNazwaGracza.Text == "")
            {
                MessageBox.Show("Podaj nazwę gracza!", "Warning");
            }
            else
            {
                Gra.gracz.Nazwa = txtNazwaGracza.Text;
                Gra.komputer.Nazwa = "Komputer";

                //ToDo
                Gra.RozmieszczenieStatkowKomputera();

                //wyświetlanie nowego okna
                Rozgrywka rozgrywka = new Rozgrywka();
                rozgrywka.Show();

                //ukrycie okna UstawienieStatów
                Hide();
            }
        }
    }
}
