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
        public string letraCorreta;
        public bool acertou = false;
    }

    public Par[] pares;
    public Button[] botoesLetra;
    public GameObject painelErro;
    public GameObject painelAcertoFinal; // Novo painel
    public GameObject painelDesafio;     // Painel a ser fechado no final
    public GameObject personagem;
    public GameObject armario;
    public GameObject mesa;
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject fogao;
    private Jogador jogador;
    public TMP_Text pontosTexto;
    public Image[] coracoes;

    private Par sinalSelecionado = null;

    void Start()
    {
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
        painelAcertoFinal.SetActive(false);
        painelErro.SetActive(false);
        painelAcertoFinal.SetActive(false);
        jogador.ResetarVidas();
        AtualizarCoracoes();

        foreach (Par par in pares)
        {
            par.botaoSinal.onClick.AddListener(() => SelecionarSinal(par));
        }

        foreach (Button letra in botoesLetra)
        {
            letra.onClick.AddListener(() => VerificarLetra(letra));
        }
        AtualizarPontosUI();
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
        if (geladeiraAberta != null)
            geladeiraAberta.SetActive(true);
        if (geladeiraFechada != null)
            geladeiraFechada.SetActive(true);
        if (fogao != null)
            fogao.SetActive(true);
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
        {
            pontosTexto.text = $"PONTOS: {jogador.pontos}";
        }
    }
    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].enabled = (i < jogador.vidas);
        }
    }

    void VerificarLetra(Button botaoLetra)
    {
        if (sinalSelecionado == null) return;

        string letraClicada = botaoLetra.GetComponentInChildren<TextMeshProUGUI>().text;

        if (sinalSelecionado.letraCorreta == letraClicada)
        {
            jogador.pontos++;
            AtualizarPontosUI();
            sinalSelecionado.acertou = true;
            sinalSelecionado.botaoSinal.interactable = false;
            botaoLetra.interactable = false;

            sinalSelecionado.botaoSinal.image.color = Color.green;
            botaoLetra.image.color = Color.green;

            // Verifica se todos os pares foram acertados
            if (TodosParesAcertados())
            {
                StartCoroutine(MostrarPainelAcertoFinal());
            }
        }
        else
        {
            jogador.PerderVida();
            AtualizarCoracoes();
            StartCoroutine(MostrarPainelErro());
            sinalSelecionado.botaoSinal.image.color = Color.white;
            Debug.Log($"Resposta errada! Vidas restantes: {jogador.vidas}");

            if (!jogador.EstaVivo())
            {
                jogador.pontos = 5;
                Debug.Log("Game Over!");
                PlayerPrefs.SetString("UltimaCena", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }

        sinalSelecionado = null;
    }

    bool TodosParesAcertados()
    {
        foreach (Par par in pares)
        {
            if (!par.acertou)
                return false;
        }
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
        Destroy(painelDesafio);

    }
}
