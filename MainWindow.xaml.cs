using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraYo
{
    public partial class MainWindow : Window
    {
        private double _numeritoOperador1 = 0;
        private double _numeritoOperador2 = 0;
        private string _numeritoTexto1 = "";
        private string _numeritoTexto2 = "";
        private string _operador = "";
        private string _resultado = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLimpiar(object sender, RoutedEventArgs e)
        {
            _numeritoOperador1 = 0;
            _numeritoOperador2 = 0;
            _numeritoTexto1 = "";
            _numeritoTexto2 = "";
            _operador = "";
            _resultado = "";
            pantalla.Text = "";
        }

        private void MostrarPantalla(object numero, object numero2 = null)
        {
            if(_resultado == "")
            {
                if (_operador == "")
                {
                    pantalla.Text = Convert.ToString(numero);
                }
                else
                {
                    pantalla.Text = "(" + Convert.ToString(numero) + ")" + _operador + "(" + Convert.ToString(numero2) + ")";
                }
            }
            else
            {
                pantalla.Text = "Resultado: " + _resultado;
            }
        }
        

        private void ButtonNumeros(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (_operador == "" && _numeritoTexto2 == "")
            {
                _numeritoTexto1 = _numeritoTexto1 + (string)btn.Content;
                _numeritoOperador1 = double.Parse(_numeritoTexto1);
                MostrarPantalla(_numeritoTexto1);
            }
            else
            {
                _numeritoTexto2 = _numeritoTexto2 + (string)btn.Content;
                _numeritoOperador2 = double.Parse(_numeritoTexto2);
                MostrarPantalla(_numeritoTexto1, _numeritoTexto2);
            }
        }

        private void ButtonSignos(object sender, RoutedEventArgs e)
        {
            if (_operador == "")
            {
                _numeritoOperador1 = _numeritoOperador1 * (-1);
                _numeritoTexto1 = Convert.ToString(_numeritoTexto1);
                MostrarPantalla(_numeritoTexto1);
            }
            else
            {
                _numeritoOperador2 = _numeritoOperador2 * (-1);
                _numeritoTexto2 = Convert.ToString(_numeritoTexto2);
                MostrarPantalla(_numeritoTexto1, _numeritoTexto2);
            }
        }

        private void ButtonPunto(object sender, RoutedEventArgs e)
        {
            if (_operador =="" && _numeritoTexto1 != "")
            {
                _numeritoTexto1 = _numeritoTexto1 + ".";
                MostrarPantalla(_numeritoTexto1);
            }

            if (_operador != "" && _numeritoTexto2 != "")
            {
                _numeritoTexto2 = _numeritoTexto2 + ".";
                MostrarPantalla(_numeritoTexto2);
            }
        }

        private void ButtonOperadores(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (_operador == "" && _numeritoTexto2 == "") 
            {
                _operador = (string)btn.Content;
                MostrarPantalla(_numeritoTexto1);
            }
        }

        private void ButtonIgual(object sender, RoutedEventArgs e)
        {
            if (_operador != "")
            {
                switch (_operador)
                {
                    case "+":
                        _resultado = Convert.ToString(_numeritoOperador1 + _numeritoOperador2);
                        break;
                    case "-":
                        _resultado = Convert.ToString(_numeritoOperador1 - _numeritoOperador2);
                        break;
                    case "x":
                        _resultado = Convert.ToString(_numeritoOperador1 * _numeritoOperador2);
                        break;
                    case "/":
                        _resultado = Convert.ToString(_numeritoOperador1 / _numeritoOperador2);
                        break;
                }
                MostrarPantalla(_resultado);
            }
        }
    
    }
}
