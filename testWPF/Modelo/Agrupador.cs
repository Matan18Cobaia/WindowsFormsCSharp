using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace NPS.Modelo
{
  public class Agrupador
  {
    public Lista Exclusivo = new Lista();
    public Lista Padrao = new Lista();
    public Lista outros = new Lista();
    public Lista operadors = new Lista();

    /// <summary>
    /// Converte a Lista de funcionários em Operador, separando entre Exclusivo, Padrao, e outros funcionarios
    /// </summary>
    /// <param name="linha"></param>
    public void ConverterLinhaEmOperador(string linha)
    {
      var campos = linha.Split(',');
      var data = campos[0].Split('/');
      var DataTime = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0]));
      int matricula = 0;
      if (campos[1] != "")
        matricula = int.Parse(campos[1]);
      var Nome = campos[3];
      var entrada = campos[4].Split(':');
      TimeSpan horario;
      if (entrada[0] != "")
      {
        horario = new TimeSpan(int.Parse(entrada[0]), int.Parse(entrada[1]), 0);
      }
      else
      {
        horario = new TimeSpan();
      }
      var usuario = campos[6];
      var fila = campos[7];
      var supervisor = campos[8];
      var operador = new Operador(DataTime, supervisor, matricula, Nome, usuario, horario);
      if (fila.ToLower() == "exclusivo")
      {
        this.Exclusivo.Add(operador, this);
      }
      else if (fila == "Padrão")
      {
        this.Padrao.Add(operador, this);
      }
      else
      {
        this.outros.Add(operador, outros);
      }

    }
    public void AtualizarLista()
    {
      operadors.Clear();
      foreach (Operador operador in Padrao)
      {
        operadors.Add(operador);
      }
      foreach (Operador operador in Exclusivo)
      {
        operadors.Add(operador);
      }
    }

    internal void AtualizarExibicao(ObservableCollection<Operador> exibicao)
    {
      exibicao.Clear();
      foreach (Operador operador in operadors)
      {
        exibicao.Add(operador);
      }
    }
    public void ConverterLinhaEmNota(string linha)
    {
      var campos = linha.Split(',');
      //var data = campos[0];
      //var usuario = campos[1];
      var operador = campos[0];
      //var n_atendimento = campos[3];
      //var sucesso = campos[4];
      var notaAtendente = int.Parse(campos[1]);
      //var notaSky = int.Parse(campos[2]);

      if (operador.StartsWith("¶"))
      {
        Exclusivo.Add(new Operador(operador), notaAtendente);
      }
      else
      {
        Padrao.Add(new Operador(operador), notaAtendente);
      }

    }

    public void Ordenar(ObservableCollection<Operador> operadors)
    {
      var Lista = operadors as IEnumerable<Operador>;
      var Ordenada = Lista.OrderBy(msg => msg.NPS);
    }

  }
}

