using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PainelDesafio3 : MonoBehaviour
{
    public GameObject painelUI;
    public List<Button> botoes;
    public Image imagemDoObjetoUI; // <- Adicione esse campo

    private Movel movelAtual;
    private Jogador jogador;
    public TMP_Text pontosTexto;
    public Image[] coracoes;

    void Start()
    {
        painelUI.SetActive(false);
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
        jogador.ResetarVidas();
        AtualizarCoracoes();
        AtualizarPontosUI();
    }
    void Update()
    {
        AtualizarCoracoes();
        AtualizarPontosUI();
    }

    public void AbrirPainel(Movel movel)
    {
        movelAtual = movel;
        painelUI.SetActive(true);

        // Ativar todos os botões de Libras
        foreach (Button b in botoes) b.gameObject.SetActive(true);

        // Mostrar a imagem do objeto atual
        imagemDoObjetoUI.sprite = movel.imagemDoObjeto;
        imagemDoObjetoUI.enabled = true;
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
            DesabilitarBotao(nomeEscolhido);
            painelUI.SetActive(false);
        }
        else
        {
            // Feedback de erro (opcional)
        }
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
