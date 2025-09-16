namespace API.Models;
public class Produto
{
    //C#
    //Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    //Atributos|Propriedades|Caractesticas da classe
    

    public string Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public double Preço { get; set; }
    public DateTime CriadoEm { get; set; }
    


    //JAVA
    //private string nome;

    //public string getNome()
    //{
    // return nome;
    //}

    //public void setNome(string nome)
    // {
    //    this.nome = nome;
    //}
}
