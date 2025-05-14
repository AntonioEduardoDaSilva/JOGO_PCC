[System.Serializable]
public class Jogador
{
    public string nomeCompleto;
    public string nomeUsuario;
    public int idade;

    public Jogador(string nomeCompleto, string nomeUsuario, int idade)
    {
        this.nomeCompleto = nomeCompleto;
        this.nomeUsuario = nomeUsuario;
        this.idade = idade;
    }
}
