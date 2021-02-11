namespace Shows
{
  public abstract class EntidadeBase
  {
    public int Id { get; protected set; }
    public Genero Genero { get; protected set; }
    public string Titulo { get; protected set; }
    public string Descricao { get; protected set; }
    public int Ano { get; protected set; }
    public bool Excluido { get; protected set; }
  }
}