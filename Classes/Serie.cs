using System;
using Shows;
namespace Series
{
  public class Serie : EntidadeBase
  {

    private int Episodios { get; set; }

    public Serie(int id, Genero genero, string titulo, string descricao, int ano, int episodios)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Episodios = episodios;
      this.Excluido = false;
    }

    public override string ToString()
    {
      // Environment.NewLine == nova linha. 
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Título: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
      retorno += "Número de episódios: " + this.Episodios + Environment.NewLine;
      retorno += "Excluido: " + this.Excluido;
      return retorno;
    }

    public string retornaTitulo()
    {
      return this.Titulo;
    }

    public int retornaId()
    {
      return this.Id;
    }

    public bool retornaExcluido()
    {
      return this.Excluido;
    }

    public void Excluir()
    {
      this.Excluido = true;
    }

  }
}