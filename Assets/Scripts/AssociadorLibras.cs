using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AssociadorLibras : MonoBehaviour
{
    [System.Serializable]
    public class Par
    {
        public Button botaoSinal;
        [HideInInspector] public string letraCorreta;
        [HideInInspector] public bool acertou = false;
    }

    [System.Serializable]
    public class Desafio
    {
        public string nomeDesafio;
        public Sprite[] imagensSinais;
        public string[] letrasCorretas;
        public GameObject objetoAtiador;
    }
    public GameObject botaoColetar;
    public Par[] pares;
    public Button[] botoesLetra;
    public Desafio[] desafios;
    public GameObject painelErro;
    public GameObject painelAcertoFinal;
    public GameObject painelDesafio;
    public GameObject personagem;
    public GameObject armario;
    public GameObject mesa;
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject fogao;
    public GameObject ovo;
    public GameObject pao;
    public GameObject queijo;
    public GameObject tomate;
    public GameObject manteiga;
    public GameObject maca;
    public GameObject kiwi;
    public GameObject uva;
    private Jogador jogador;
    public TMP_Text pontosTexto;
    public Image[] coracoes;
    private int indiceDesafioAtual = -1;
    public static int pontosNivel = 0;
    public static int errosNivel = 0;

    private Par sinalSelecionado = null;

    void Start()
    {
        pontosNivel = 0;
        errosNivel = 0;
        if (botaoColetar != null)
            botaoColetar.SetActive(false);
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
        painelAcertoFinal.SetActive(false);
        painelErro.SetActive(false);
        jogador.ResetarVidas();
        AtualizarCoracoes();
        AtualizarPontosUI();

        foreach (Par par in pares)
        {
            par.botaoSinal.onClick.AddListener(() => SelecionarSinal(par));
        }

        foreach (Button letra in botoesLetra)
        {
            letra.onClick.AddListener(() => VerificarLetra(letra));
        }
    }

    void Update()
    {
        AtualizarCoracoes();
        AtualizarPontosUI();
    }

    void mostrarObjetos()
    {
        if (personagem != null)
            personagem.SetActive(true);
        if (armario != null)
            armario.SetActive(true);
        if (mesa != null)
            mesa.SetActive(true);
        if (geladeiraFechada != null)
            geladeiraFechada.SetActive(true);
        if (fogao != null)
            fogao.SetActive(true);
        if (pao != null && GameManager.lancheEscolhido == "pao")
            pao.SetActive(true);
        if (queijo != null && GameManager.lancheEscolhido == "pao")
            queijo.SetActive(true);
        if (manteiga != null && (GameManager.lancheEscolhido == "pao" || GameManager.lancheEscolhido == "omelete"))
            manteiga.SetActive(true);
        if (maca != null && GameManager.lancheEscolhido == "salada")
            maca.SetActive(true);
        if (kiwi != null && GameManager.lancheEscolhido == "salada")
            kiwi.SetActive(true);
        if (uva != null && GameManager.lancheEscolhido == "salada")
            uva.SetActive(true);
        if (tomate != null && GameManager.lancheEscolhido == "omelete")
            tomate.SetActive(true);
    }

    void SelecionarSinal(Par par)
    {
        if (par.acertou) return;

        sinalSelecionado = par;

        foreach (Par p in pares)
            p.botaoSinal.image.color = Color.white;

        par.botaoSinal.image.color = Color.yellow;
    }

    void AtualizarPontosUI()
    {
        if (pontosTexto != null)
            pontosTexto.text = $"PONTOS: {jogador.pontos}";
    }

    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
            coracoes[i].enabled = (i < jogador.vidas);
    }
    void DestruirObjetoDoDesafioAtual()
{
    if (indiceDesafioAtual >= 0 && indiceDesafioAtual < desafios.Length)
    {
        GameObject ativador = desafios[indiceDesafioAtual].objetoAtiador;
        if (ativador != null)
        {
            Destroy(ativador);
        }
    }
}

    void VerificarLetra(Button botaoLetra)
    {
        if (sinalSelecionado == null) return;

        string letraClicada = botaoLetra.GetComponentInChildren<TextMeshProUGUI>().text;

        if (sinalSelecionado.letraCorreta == letraClicada)
        {
            jogador.pontos++;
            pontosNivel++;
            AtualizarPontosUI();
            sinalSelecionado.acertou = true;
            sinalSelecionado.botaoSinal.interactable = false;
            botaoLetra.interactable = false;

            sinalSelecionado.botaoSinal.image.color = Color.green;
            botaoLetra.image.color = Color.green;
            StartCoroutine(MostrarPainelAcerto());

            if (TodosParesAcertados())
            {
                StartCoroutine(MostrarPainelAcertoFinal());
                DestruirObjetoDoDesafioAtual();
            }
        }
        else
        {
            jogador.PerderVida();
            errosNivel++;
            AtualizarCoracoes();
            StartCoroutine(MostrarPainelErro());
            sinalSelecionado.botaoSinal.image.color = Color.white;

            if (!jogador.EstaVivo())
            {
                jogador.pontos = 5;
                PlayerPrefs.SetString("CenaAnterior", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }

        sinalSelecionado = null;
    }

    bool TodosParesAcertados()
    {
        foreach (Par par in pares)
            if (!par.acertou) return false;
        return true;
    }

    System.Collections.IEnumerator MostrarPainelErro()
    {
        painelErro.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        painelErro.SetActive(false);
    }

    System.Collections.IEnumerator MostrarPainelAcertoFinal()
    {
        painelAcertoFinal.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelAcertoFinal.SetActive(false);
        painelDesafio.SetActive(false);
        mostrarObjetos();
        painelDesafio.SetActive(false);
    }
    System.Collections.IEnumerator MostrarPainelAcerto()
    {
        painelAcertoFinal.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelAcertoFinal.SetActive(false);
    }
    public void CarregarDesafio(int indice)
    {
        if (indice < 0 || indice >= desafios.Length) return;

        indiceDesafioAtual = indice; // ← armazena o índice atual

        Desafio desafio = desafios[indice];

        for (int i = 0; i < pares.Length; i++)
        {
            pares[i].acertou = false;
            pares[i].botaoSinal.interactable = true;
            pares[i].botaoSinal.image.color = Color.white;

            if (i < desafio.imagensSinais.Length)
                pares[i].botaoSinal.image.sprite = desafio.imagensSinais[i];

            if (i < desafio.letrasCorretas.Length)
                pares[i].letraCorreta = desafio.letrasCorretas[i];
        }

        for (int i = 0; i < botoesLetra.Length; i++)
        {
            botoesLetra[i].interactable = true;
            botoesLetra[i].image.color = Color.white;

            if (i < desafio.letrasCorretas.Length)
                botoesLetra[i].GetComponentInChildren<TextMeshProUGUI>().text = desafio.letrasCorretas[i];
        }

        painelDesafio.SetActive(true);
    }

}
