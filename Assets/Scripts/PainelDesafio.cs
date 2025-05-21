using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PainelDesafio : MonoBehaviour
{
    public GameObject painelDesafio;
    public GameObject sinalPositivo;
    public GameObject sinalNegativo;
    public Button[] botoesResposta;
    public int indiceCorreta = 0;
    public GameObject objetoColetado;
    public TMP_Text pontosTexto;
    public Image[] coracoes;
    public GameObject personagem;
    public GameObject aviao;
    public GameObject espelho;
    private Jogador jogador;
    private bool desafioConcluido = false;
    private bool desafioConcluido1 = false;
    private int pontos = 0;
    public string[] novosTextos;

    void Start()
    {
        painelDesafio.SetActive(false);
        sinalPositivo.SetActive(false);
        sinalNegativo.SetActive(false);

        jogador = GerenciadorJogadores.instancia.jogadorAtual;

        if (jogador == null)
        {
            Debug.LogError("Jogador atual não encontrado!");
            return;
        }

        AtualizarPontosUI();
        AtualizarCoracoes();
    }

    public void AbrirPainel()
    {
        if (!desafioConcluido)
        {
            painelDesafio.SetActive(true);
            AtribuirListeners();

            if (personagem != null)
                personagem.SetActive(false);
            if (aviao != null)
                aviao.SetActive(false);
            if (espelho != null)
                espelho.SetActive(false);
            
        }
    }
    public void AbrirPainel1()
    {
        if (!desafioConcluido1)
        {
            AtualizarTextosDosBotoes();
            painelDesafio.SetActive(true);
            AtribuirListeners();

            if (personagem != null)
                personagem.SetActive(false);
            if (aviao != null)
                aviao.SetActive(false);
            if (espelho != null)
                espelho.SetActive(false);
            
        }
    }
   void AtualizarTextosDosBotoes()
    {
        // Textos definidos localmente aqui
        string[] novosTextos = { "E", "G", "P", "U" };

        for (int i = 0; i < botoesResposta.Length; i++)
        {
            if (i < novosTextos.Length)
            {
                TMP_Text textoBotao = botoesResposta[i].GetComponentInChildren<TMP_Text>();
                if (textoBotao != null)
                {
                    textoBotao.text = novosTextos[i];
                }
                else
                {
                    Debug.LogWarning("Botão sem TMP_Text: " + botoesResposta[i].name);
                }
            }
        }
    }

    void AtribuirListeners()
    {
        for (int i = 0; i < botoesResposta.Length; i++)
        {
            int index = i;
            botoesResposta[i].onClick.RemoveAllListeners();
            botoesResposta[i].onClick.AddListener(() => VerificarResposta(index));
        }
    }

    public void VerificarResposta(int indiceEscolhido)
    {
        Debug.Log($"Clique detectado no botão {indiceEscolhido}");

        if (desafioConcluido || jogador == null) return;

        if (indiceEscolhido == indiceCorreta)
        {
            pontos++;
            AtualizarPontosUI();

            sinalPositivo.SetActive(true);
            Invoke("FecharPainel", 2f);
            desafioConcluido = true;
            Debug.Log("Resposta correta!");

            if (objetoColetado != null)
            {
                Destroy(objetoColetado);
            }
        }
        else
        {
            jogador.PerderVida();
            AtualizarCoracoes();
            sinalNegativo.SetActive(true);
            Invoke("FecharPainelNegativo", 2f);

            Debug.Log($"Resposta errada! Vidas restantes: {jogador.vidas}");

            if (!jogador.EstaVivo())
            {
                Debug.Log("Game Over!");
                PlayerPrefs.SetString("UltimaCena", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }
    }

    void AtualizarPontosUI()
    {
        if (pontosTexto != null)
        {
            pontosTexto.text = $"PONTOS: {pontos}";
        }
    }

    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].enabled = (i < jogador.vidas);
        }
    }

    void FecharPainel()
    {
        painelDesafio.SetActive(false);
        sinalPositivo.SetActive(false);

        if (personagem != null)
            personagem.SetActive(true);
        if (aviao != null)
            aviao.SetActive(true);
        if (espelho != null)
            espelho.SetActive(true);
    }

    void FecharPainelNegativo()
    {
        sinalNegativo.SetActive(false);
    }
}
