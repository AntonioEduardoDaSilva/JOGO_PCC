[System.Serializable]
public class Jogador
{
    public string nomeCompleto;
    public string nomeUsuario;
    public int idade;
    public int vidas = 5;

    public Jogador(string nomeCompleto, string nomeUsuario, int idade, int vidas = 5)
    {
        this.nomeCompleto = nomeCompleto;
        this.nomeUsuario = nomeUsuario;
        this.idade = idade;
        this.vidas = vidas;
    }

        public void PerderVida()
    {
        if (vidas > 0)
            vidas--;
    }

    public bool EstaVivo()
    {
        return vidas > 0;
    }
}
