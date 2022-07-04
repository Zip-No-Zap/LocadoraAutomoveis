using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;


namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public static class ValidadorCampos
    {
        public static KeyPressEventArgs ImpedirNumeroECharsEspeciaisTextBox(KeyPressEventArgs e)
        {
            if ((Strings.Asc(e.KeyChar) >= 48 & Strings.Asc(e.KeyChar) <= 57))
            {
                e.Handled = true;
            }

            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }

            return e;
        }

        public static void ImpedirLetrasCharEspeciais(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        public static void ValidarCampoEmail(KeyPressEventArgs e)
        {
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_@.";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper()) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void ImpedirCharEspeciais(KeyPressEventArgs e)
        {
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 .-";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper()) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static bool ValidarCampoData(string data)
        {
            DateTime date = new();

            if (DateTime.TryParse(data, out date) == false)
                return false;

            return true;
        }


        public static void ValidarCampoLogin(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')))
            {
                e.Handled = true;
            }
        }

        public static void ImpedirTextoMenorDois(string texto)
        {
            if (texto.Length < 2)
            {
                return;
            }
        }

        public static void ValidadorAno(KeyPressEventArgs e)
        {
            string caracteresPermitidos = "0123456789";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper()) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void ValidadorPlacaVeiculo(KeyPressEventArgs e)
        {
            string caracteresPermitidos = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper()) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void ValidadorCorVeiculo(KeyPressEventArgs e)
        {
            string caracteresPermitidos = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper()) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

    }
}
