using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPS.Modelo
{
  public class Leitor
  {
    public void Ler(string endereco, Agrupador agrupador)
    {
      List<string> lista = new List<string>();
      using (var fs = new FileStream(endereco, FileMode.Open))
      using (var leitor = new StreamReader(fs))
      {
        leitor.ReadLine();
        while (!leitor.EndOfStream)
        {
          var linha = leitor.ReadLine();
          lista.Add(linha);
        }
      }
      foreach (string linha in lista)
        agrupador.ConverterLinhaEmNota(linha);
      lista.Clear();
      agrupador.AtualizarLista();


    }
    public void LerLista(string endereco, Agrupador agrupador)
    {
      Encoding encoding = new UTF8Encoding();
      List<string> lista = new List<string>();
      using (var fs = new FileStream(endereco, FileMode.Open))
      using (var leitor = new StreamReader(fs, encoding))
      {
        leitor.ReadLine();
        while (!leitor.EndOfStream)
        {
          var linha = leitor.ReadLine();
          lista.Add(linha);
        }
      }

      var tasks = lista.Select(linha =>
      {
        return Task.Factory.StartNew(() =>
              {
                agrupador.ConverterLinhaEmOperador(linha);
              });
      }).ToArray();

      Task.WaitAll(tasks);

      lista.Clear();
      agrupador.operadors.Clear();
      agrupador.AtualizarLista();

    }



  }
}
