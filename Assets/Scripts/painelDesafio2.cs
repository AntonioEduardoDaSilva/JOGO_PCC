using UnityEngine;

public class painelDesafio2 : MonoBehaviour
{
    public GameObject painelDesafio;
    public GameObject personagem;
    public GameObject armario;
    public GameObject mesa;
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject fogao;
    public GameObject painelRespostaErrada;
    public GameObject painelAcertoFinal;
    //public GameObject ovo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelAcertoFinal.SetActive(false);
        painelDesafio.SetActive(false);
        painelRespostaErrada.SetActive(false);
        mostrarObjetos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AbrirPainel()
    {
        painelDesafio.SetActive(true);
        geladeiraAberta.SetActive(false);
        esconderObjetos();
    }
    void esconderObjetos()
    {
        if (personagem != null)
            personagem.SetActive(false);
        if (armario != null)
            armario.SetActive(false);
        if (mesa != null)
            mesa.SetActive(false);
        if (geladeiraAberta != null)
            geladeiraAberta.SetActive(false);
        if (geladeiraFechada != null)
            geladeiraFechada.SetActive(false);
        if (fogao != null)
            fogao.SetActive(false);
    }
    void mostrarObjetos()
    {
        if (personagem != null)
            personagem.SetActive(true);
        if (armario != null)
            armario.SetActive(true);
        if (mesa != null)
            mesa.SetActive(true);
        if (geladeiraAberta != null)
            geladeiraAberta.SetActive(true);
        if (geladeiraFechada != null)
            geladeiraFechada.SetActive(true);
        if (fogao != null)
            fogao.SetActive(true);
    }
}
