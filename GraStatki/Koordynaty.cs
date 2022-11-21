using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraStatki
{
    public static class Koordynaty
    {
        //pobieranie współrzędnej X
        public static int PobierzX(Form form, PictureBox pictureBox)
        {
            //obramowanie
            //form.Width - szerokość okna z obramowaniem
            //form.ClientSize.Width - szerokość okna wewnątrz

            int obramowanieOkna = (form.Width - form.ClientSize.Width) / 2;

            //obliczanie współrzędnej
            int wspolrzednaX = Control.MousePosition.X - form.Location.X - pictureBox.Location.X - obramowanieOkna;

            return wspolrzednaX;
        }

        //pobieranie współrzędnej Y
    }
}
