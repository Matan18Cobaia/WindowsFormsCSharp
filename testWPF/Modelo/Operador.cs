using System;

namespace NPS.Modelo
{
  public class Operador
  {
    //Propriedades DB
    public DateTime DataEntrada { get; private set; }
    public string Supervisor { get; private set; }
    public int Matricula { get; private set; }
    public string NomeCompleto { get; private set; }
    public string Usuario { get; private set; }
    public TimeSpan Horario { get; private set; }
    //Fim Proprieadades DB
    //Propriedades NPS
    public string Nome { get; private set; }
    public int[] Notas = new int[10];
    public double NPS { get; private set; }

    /// <summary>
    /// Construtor com Nome
    /// </summary>
    /// <param name="nome"></param>
    public Operador(string nome)
    {
      this.Nome = nome;
    }

    /// <summary>
    /// Construtor com DB
    /// </summary>
    /// <param name="dataEntrada"></param>
    /// <param name="supervisor"></param>
    /// <param name="matricula"></param>
    /// <param name="nomeCompleto"></param>
    /// <param name="usuario"></param>
    /// <param name="horario"></param>
    public Operador(DateTime dataEntrada, string supervisor, int matricula, string nomeCompleto, string usuario, TimeSpan horario)
    {
      this.DataEntrada = dataEntrada;
      this.Supervisor = supervisor;
      this.Matricula = matricula;
      this.NomeCompleto = nomeCompleto;
      this.Usuario = usuario;
      this.Horario = horario;
    }

    /// <summary>
    /// Adiciona as propriedades neste operador
    /// </summary>
    /// <param name="dataEntrada"></param>
    /// <param name="supervisor"></param>
    /// <param name="matricula"></param>
    /// <param name="nomeCompleto"></param>
    /// <param name="usuario"></param>
    /// <param name="horario"></param>
    internal void Dados(DateTime dataEntrada, string supervisor, int matricula, string nomeCompleto, string usuario, TimeSpan horario)
    {
      this.DataEntrada = dataEntrada;
      this.Supervisor = supervisor;
      this.Matricula = matricula;
      this.NomeCompleto = nomeCompleto;
      this.Usuario = usuario;
      this.Horario = horario;
    }


    /// <summary>
    /// Adiciona nota a este operador
    /// </summary>
    /// <param name="nota"></param>
    public void AddNote(int nota)
    {
      this.Notas[nota - 1]++;
      this.getNPS();
    }



    /// <summary>
    /// Calcula NPS desse Operador
    /// </summary>
    public void getNPS()
    {
      int Boas = this.Notas[8] + this.Notas[9];
      int Ruins = 0;
      double Total = 0;
      for (int i = 0; i < 6; i++)
      {
        Ruins += this.Notas[i];
      }
      for (int i = 0; i < 10; i++)
      {
        Total += this.Notas[i];
      }
      double a = (100 * (Boas - Ruins) / Total);

      NPS = Math.Round(a, 2);
      //O problema está aqui!!!! NPS está como int
    }
    public override string ToString()
    {
      return Nome;
    }

  }
}
