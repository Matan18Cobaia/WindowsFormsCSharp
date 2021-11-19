using System;
using System.Collections.Generic;

namespace NPS.Modelo
{
  public class Lista : List<Operador>
  {
    public int[] Notas = new int[10];
    public double NPS { get; private set; }

    public bool verificaOperador(Operador operador, int nota)
    {
      foreach (Operador Item in this)
      {
        if (Item.Nome == operador.Nome)
        {
          this.AddNota(Item, nota);
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Adiciona Operador e Nota
    /// </summary>
    /// <param name="operador"></param>
    /// <param name="nota"></param>
    /// <returns></returns>
    public void Add(Operador newoperador, int nota)
    {
      if (false == verificaOperador(newoperador, nota))
      {
        this.Add(newoperador);
        this.AddNota(newoperador, nota);
      }

    }
    public void Add(Operador operador, Lista operadores)
    {
      this.Add(operador);
    }


    /// <summary>
    /// Adiciona verifica se o operador já existe e adiciona propriedades DB a ele
    /// </summary>
    /// <param name="operador"></param>
    /// <param name="over"></param>
    public int Add(Operador operador, Agrupador agrupador)
    {
      foreach (Operador item in this)
      {
        try
        {
          var Nome = item.Nome.Remove(0, 1);
          var nomes = Nome.Split(' ');

          try
          {
            if (item.Nome != null || item.Nome != "")

              if (operador.NomeCompleto.ToLower().Contains(nomes[0].ToLower()) && item.Nome.ToLower().Contains(nomes[1].ToLower()))
              {
                item.Dados(operador.DataEntrada, operador.Supervisor, operador.Matricula, operador.NomeCompleto, operador.Usuario, operador.Horario);
                return 1;
              }
          }
          catch (IndexOutOfRangeException)
          {
            if (operador.NomeCompleto.ToLower().Contains(nomes[0].ToLower()))
            {
              item.Dados(operador.DataEntrada, operador.Supervisor, operador.Matricula, operador.NomeCompleto, operador.Usuario, operador.Horario);
              return 1;
            }
          }
        }
        catch (NullReferenceException)
        {
          if (item.NomeCompleto == operador.NomeCompleto)
            return 0;
        }
      }
      agrupador.operadors.Add(operador);
      return 0;
    }




    /// <summary>
    /// Adiciona nota ao operador e à Lista
    /// </summary>
    /// <param name="operador"></param>
    /// <param name="nota"></param>
    public void AddNota(Operador operador, int nota)
    {
      operador.AddNote(nota);
      this.Notas[nota - 1]++;
    }


    /// <summary>
    /// Calcula a NPS da Lista
    /// </summary>
    public void getNPS()
    {
      int Boas = Notas[8] + Notas[9];
      int Ruins = 0;
      int Total = 0;
      for (int i = 0; i < 6; i++)
      {
        Ruins += Notas[i];
      }
      for (int i = 0; i < 10; i++)
      {
        Total += Notas[i];
      }
      NPS = (Boas - Ruins) / Total;
    }

  }
}
