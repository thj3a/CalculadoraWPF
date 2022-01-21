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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string? valorAdicionar = null;
        double? numeroAtual = null;
        string? operador = null;

        string[] tiposOperadores = { "+", "-", "/", "*" };

        private void Botao_Numeros(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == BotaoVirgula.Name && valorAdicionar != null && valorAdicionar.Contains(",")) { }
            else
            {
                valorAdicionar += btn.Content.ToString();
                Equacao.Text = numeroAtual + operador + valorAdicionar;
            }
        }
        private void Botao_Operadores(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (numeroAtual.HasValue && valorAdicionar != null && operador != null )
            {
                FazOperacao(Convert.ToDouble(numeroAtual), Convert.ToDouble(double.Parse(valorAdicionar)), operador);
            }
            else if (!numeroAtual.HasValue)
            {
                numeroAtual = Convert.ToDouble(valorAdicionar);
            }
            valorAdicionar = null;
            operador = btn.Content.ToString();
            Equacao.Text = numeroAtual.ToString() + operador + valorAdicionar;
        }

        private void Botao_Limpar(object sender, RoutedEventArgs e)
        {
            numeroAtual = null;
            valorAdicionar = null;
            operador = null;
            Equacao.Clear();
        }
        private void FazOperacao(double num1, double num2, string Operador)
        {
                double resultado;
                switch (Operador)
                {
                    case "+":
                        resultado = (num1 + num2);
                        break;
                    case "-":
                        resultado = (num1 - num2);
                        break;
                    case "*":
                        resultado = (num1 * num2);
                        break;

                    case "/":
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
            numeroAtual = resultado;
            Equacao.Text = numeroAtual.ToString();
        }
        private void Botao_Resultado(object sender, RoutedEventArgs e)
        {
            if (numeroAtual != null && valorAdicionar != null && operador != null)
            {
                FazOperacao(Convert.ToDouble(numeroAtual), double.Parse(valorAdicionar), operador);
                valorAdicionar = null;
            }
        }
    }
}
