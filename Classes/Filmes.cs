using System;
using Shows;
namespace Filmes
{
  public class Filmes : EntidadeBase
  {
    private int Duracao { get; set; }

    public Filmes(int id, Genero genero, string titulo, string descricao, int ano, int duracao)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Duracao = duracao;
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
      retorno += "Duração (em minutos): " + this.Duracao + Environment.NewLine;
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