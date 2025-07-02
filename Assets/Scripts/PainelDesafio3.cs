using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PainelDesafio3 : MonoBehaviour
{
    public GameObject painelUI;
    public List<Button> botoes;
    public Image imagemDoObjetoUI; // <- Adicione esse campo

    private Movel movelAtual;
    void start()
    {
        painelUI.SetActive(false);
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
