using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PainelDesafio3 : MonoBehaviour
{
    public GameObject painelUI;
    public List<Button> botoes;
    public Image imagemDoObjetoUI;
    public Transform painelOrnamentacao;

    private Movel movelAtual;
    private Jogador jogador;
    public TMP_Text pontosTexto;
    public Image[] coracoes;
    public GameObject sinalPositivo;
    public GameObject sinalNegativo;
    public GameObject personagem;
    public static int pontosNivel = 0;
    public static int errosNivel = 0;

    void Start()
    {
        pontosNivel = 0;
        errosNivel = 0;
        painelUI.SetActive(false);
        sinalNegativo.SetActive(false);
        sinalPositivo.SetActive(false);
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
        jogador.ResetarVidas();
        AtualizarCoracoes();
        AtualizarPontosUI();
    }
    void Update()
    {
        AtualizarCoracoes();
        AtualizarPontosUI();
        nivelConcluido();
    }
    void FecharPainel()
    {
        sinalNegativo.SetActive(false);
        sinalPositivo.SetActive(false);
        painelUI.SetActive(false);
        personagem.SetActive(true);

        Movel.MostrarTodosLibras();
    }

    public void AbrirPainel(Movel movel)
    {
        movelAtual = movel;
        painelUI.SetActive(true);
        personagem.SetActive(false);

        Movel.EsconderTodosLibras();

        foreach (Button b in botoes)
            b.gameObject.SetActive(true);

        imagemDoObjetoUI.sprite = movel.imagemDoObjeto;
        imagemDoObjetoUI.enabled = true;
    }

    public void nivelConcluido()
    {
        if (pontosNivel >= 5)
        {
            PlayerPrefs.SetString("CenaAnterior", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("NivelConcluido");
        }
    }
    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
            coracoes[i].enabled = (i < jogador.vidas);
    }
    void AtualizarPontosUI()
    {
        if (pontosTexto != null)
            pontosTexto.text = $"PONTOS: {jogador.pontos}";
    }
    System.Collections.IEnumerator Esperar2Segundos()
    {
        Debug.Log("Esperando 2 segundos...");
        yield return new WaitForSeconds(2f);
        Debug.Log("2 segundos se passaram!");
    }
    public void EscolherResposta(string nomeEscolhido)
    {
        if (nomeEscolhido == movelAtual.nomeMovel)
        {
            movelAtual.foiRespondido = true;
            DesabilitarBotao(nomeEscolhido);
            jogador.pontos++;
            pontosNivel++;
            sinalPositivo.SetActive(true);
            Invoke("FecharPainel", 2f);
            StartCoroutine(Esperar2Segundos());
            movelAtual.MostrarLibrasAoLado();
            movelAtual.MostrarLibrasUI(painelOrnamentacao);
        }
        else
        {
            Debug.Log("Resposta errada: mostrando painel de erro");

            jogador.PerderVida();
            errosNivel++;
            AtualizarCoracoes();
            StartCoroutine(MostrarErroTemporario());

            Debug.Log($"Resposta errada! Vidas restantes: {jogador.vidas}");

            if (!jogador.EstaVivo())
            {
                Debug.Log("Game Over!");
                PlayerPrefs.SetString("CenaAnterior", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }
    }
    private System.Collections.IEnumerator MostrarErroTemporario()
{
    sinalNegativo.SetActive(true);        
    yield return new WaitForSeconds(2f); 
    sinalNegativo.SetActive(false);       
}


    void DesabilitarBotao(string nome)
    {
        foreach (Button b in botoes)
        {
            if (b.name.ToLower().Contains(nome.ToLower()))
            {
                b.interactable = false;
            }
        }
    }
}
