using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject ovo;
    public GameObject pao;
    public GameObject queijo;
    public GameObject tomate;
    public GameObject manteiga;
    public GameObject maca;
    public GameObject kiwi;
    public GameObject uva;
    private Jogador jogador;

    //public GameObject ovo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelAcertoFinal.SetActive(false);
        painelDesafio.SetActive(false);
        painelRespostaErrada.SetActive(false);
        mostrarObjetos();
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
    }

    // Update is called once per frame
    void Update()
    {
        nivelConcluido();
    }
    public void nivelConcluido()
    {
        if (AssociadorLibras.pontosNivel >= 12)
        {
            PlayerPrefs.SetString("CenaAnterior", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("NivelConcluido");
        }
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
        if (ovo != null)
            ovo.SetActive(false);
        if (pao != null)
            pao.SetActive(false);
        if (queijo != null)
            queijo.SetActive(false);
        if (tomate != null)
            tomate.SetActive(false);
        if (manteiga != null)
            manteiga.SetActive(false);
        if (maca != null)
            maca.SetActive(false);
        if (kiwi != null)
            kiwi.SetActive(false);
        if (uva != null)
            uva.SetActive(false);
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
        //if (ovo != null)
        //    ovo.SetActive(true);
        if (pao != null && GameManager.lancheEscolhido == "pao")
            pao.SetActive(true);
        if (tomate != null && GameManager.lancheEscolhido == "omelete")
            tomate.SetActive(true);
        if (manteiga != null && (GameManager.lancheEscolhido == "pao" || GameManager.lancheEscolhido == "omelete"))
            manteiga.SetActive(true);
        if (maca != null && GameManager.lancheEscolhido == "salada")
            maca.SetActive(true);
        if (kiwi != null && GameManager.lancheEscolhido == "salada")
            kiwi.SetActive(true);
        if (uva != null && GameManager.lancheEscolhido=="salada")
            uva.SetActive(true);
    }
}
