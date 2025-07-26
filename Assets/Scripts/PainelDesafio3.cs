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

    void Start()
    {
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

        //MostrarTodasAsImagensDeLibras();
    }
/*
        void EsconderTodasAsImagensDeLibras()
    {
        Movel[] moveis = FindObjectsOfType<Movel>();
        foreach (Movel m in moveis)
        {
            if (m.imagemLibras != null)
                m.imagemLibras.GameObject.SetActive(false);
        }
    }

    void MostrarTodasAsImagensDeLibras()
    {
        Movel[] moveis = FindObjectsOfType<Movel>();
        foreach (Movel m in moveis)
        {
            if (m.foiRespondido && m.imagemLibras != null)
                m.imagemLibras.gameObject.SetActive(true);
        }
    }
*/
    public void AbrirPainel(Movel movel)
    {
        movelAtual = movel;
        painelUI.SetActive(true);

        // Esconde todas as imagens de Libras
        //EsconderTodasAsImagensDeLibras();

        foreach (Button b in botoes)
            b.gameObject.SetActive(true);

        imagemDoObjetoUI.sprite = movel.imagemDoObjeto;
        imagemDoObjetoUI.enabled = true;
    }

    public void nivelConcluido()
    {
        if (jogador.pontos >= 22)
        {
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
    public void EscolherResposta(string nomeEscolhido)
    {
        if (nomeEscolhido == movelAtual.nomeMovel)
        {
            movelAtual.foiRespondido = true;
            movelAtual.MostrarLibrasAoLado();
            movelAtual.MostrarLibrasUI(painelOrnamentacao);
            DesabilitarBotao(nomeEscolhido);
            jogador.pontos++;
            sinalPositivo.SetActive(true);
            Invoke("FecharPainel", 2f);
            personagem.SetActive(true);
        }
        else
        {
            Debug.Log("Resposta errada: mostrando painel de erro");

            jogador.PerderVida();
            AtualizarCoracoes();
            StartCoroutine(MostrarErroTemporario());

            Debug.Log($"Resposta errada! Vidas restantes: {jogador.vidas}");

            if (!jogador.EstaVivo())
            {
                Debug.Log("Game Over!");
                PlayerPrefs.SetString("UltimaCena", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }
    }
    private System.Collections.IEnumerator MostrarErroTemporario()
{
    sinalNegativo.SetActive(true);        // Mostra o painel de erro
    yield return new WaitForSeconds(2f); // Espera 2 segundos
    sinalNegativo.SetActive(false);       // Esconde o painel de erro
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
