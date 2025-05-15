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
    private Jogador jogador;
    private bool desafioConcluido = false;
    private int pontos = 0;

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
                PlayerPrefs.SetString("UltimaCena", SceneManager.GetActiveScene().name); // <- Salva o nome da cena atual (nível)
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
            if (i < jogador.vidas)
            {
                coracoes[i].enabled = true; // Mostra o coração
            }
            else
            {
                coracoes[i].enabled = false; // Esconde o coração
            }
        }
    }

    void FecharPainel()
    {
        painelDesafio.SetActive(false);
        sinalPositivo.SetActive(false);
        sinalNegativo.SetActive(false);
    }
    void FecharPainelNegativo()
    {
        sinalNegativo.SetActive(false);
    }
}
