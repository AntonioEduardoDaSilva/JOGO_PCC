using UnityEngine;

[System.Serializable]

public class Desafio
{
    public string[] alternativas;
    public int indiceCorreto;
    public bool concluido;
    public GameObject objetoColetado;
    public GameObject ImagemDesafio;

    public Desafio(string[] alternativas, int indiceCorreto, GameObject objetoColetado, GameObject imagemDesafio)
    {
        this.alternativas = alternativas;
        this.indiceCorreto = indiceCorreto;
        this.concluido = false;
        this.objetoColetado = objetoColetado;
        this.ImagemDesafio = imagemDesafio;
    }
}
