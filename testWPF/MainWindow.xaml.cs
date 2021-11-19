using NPS.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace testWPF
{
  /// <summary>
  /// Interação lógica para MainWindow.xam
  /// </summary>
  public partial class MainWindow : Window
  {
    public string Caminho = "C:\\Users\\mateu\\Documents\\ProjectsInWindows\\CSharp\\Alura\\CSharp\\Projetos\\testWPF\\primeiro.csv";
    public Agrupador agrupador;
    public Leitor leitor = new Leitor();
    public ObservableCollection<Operador> Exibicao = new ObservableCollection<Operador>();
    public MainWindow()
    {
      agrupador = new Agrupador();
      InitializeComponent();
      AtualizarCampos();
    }
    private void AtualizarCampos()
    {
      EnderecoNotas.Text = Caminho;
      gridViewOperadores.ItemsSource = Exibicao;
    }

    private void NPS_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderByDescending(msg => msg.NPS);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);

    }

    private void Nome_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.Nome);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);
    }
    private void Supervisor_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.Supervisor);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);
    }
    private void Matricula_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.Matricula);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);
    }
    private void DataEntrada_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.DataEntrada);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);
    }
    private void Horario_Click(object sender, RoutedEventArgs e)
    {
      var Lista = Exibicao as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.Horario);
      agrupador.operadors.Clear();
      agrupador.operadors.AddRange(Ordenada);
      agrupador.AtualizarExibicao(Exibicao);
    }
    private void Aceitar_Click(object sender, RoutedEventArgs e)
    {
      Caminho = EnderecoNotas.Text;
    }

    private void CarregarLista_Click(object sender, RoutedEventArgs e)
    {
      leitor.Ler(Caminho, agrupador);
      agrupador.AtualizarExibicao(Exibicao);
      AtualizarCampos();
    }

    private void DBList_Click(object sender, RoutedEventArgs e)
    {
      leitor.LerLista(EnderecoOperadores.Text, agrupador);
      agrupador.AtualizarExibicao(Exibicao);
      gridViewOperadores.UpdateLayout();
    }
  }
}
