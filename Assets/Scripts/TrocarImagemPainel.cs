using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrocarImagemPainel : MonoBehaviour
{
    public Image painelImagem;
    public Sprite imagemDoNivel1;
    public Sprite imagemDoNivel2;
    public Sprite imagemDoNivel3;
    public Sprite imagemPadrao;
    public TMP_Text pontosNivel;
    public TMP_Text errosNivel;
    public GameObject botaoProximoNivel;
    public GameObject estrelaVazia1;
    public GameObject estrelaVazia2;
    public GameObject estrelaVazia3;
    public GameObject estrelaAmarela1;
    public GameObject estrelaAmarela2;
    public GameObject estrelaAmarela3;

    void Start()
    {
        string cenaAnterior = PlayerPrefs.GetString("CenaAnterior", "nenhuma");
        estrelaVazia1.SetActive(true);
        estrelaVazia2.SetActive(true);
        estrelaVazia2.SetActive(true);
        estrelaAmarela1.SetActive(false);
        estrelaAmarela2.SetActive(false);
        estrelaAmarela3.SetActive(false);

        switch (cenaAnterior)
        {
            case "TelaNivel1":
                painelImagem.sprite = imagemDoNivel1;
                pontosNivel.text = $"Pontos: {PainelDesafio.pontosNivel}";
                errosNivel.text = $"Erros: {PainelDesafio.errosNivel}";
                if (PainelDesafio.errosNivel <= 1)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(true);
                }
                else if (PainelDesafio.errosNivel > 1 &&PainelDesafio.errosNivel <= 3)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(false);
                }
                else if (PainelDesafio.errosNivel == 4)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(false);
                    estrelaAmarela3.SetActive(false);
                }
                break;

            case "TelaNivel2":
                painelImagem.sprite = imagemDoNivel2;
                pontosNivel.text = $"Pontos: {AssociadorLibras.pontosNivel}";
                errosNivel.text = $"Erros: {AssociadorLibras.errosNivel}";
                if (AssociadorLibras.errosNivel <= 1)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(true);
                }
                else if (AssociadorLibras.errosNivel > 1 && AssociadorLibras.errosNivel <= 3)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(false);
                }
                else if (AssociadorLibras.errosNivel == 4)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(false);
                    estrelaAmarela3.SetActive(false);
                }
                break;
            case "TelaNivel3":
                painelImagem.sprite = imagemDoNivel3;
                pontosNivel.text = $"Pontos: {PainelDesafio3.pontosNivel}";
                errosNivel.text = $"Erros: {PainelDesafio3.errosNivel}";
                botaoProximoNivel.SetActive(false);
                
                if (PainelDesafio3.errosNivel <= 1)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(true);
                }
                else if (PainelDesafio3.errosNivel > 1 && PainelDesafio3.errosNivel <= 3)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(true);
                    estrelaAmarela3.SetActive(false);
                }
                else if (PainelDesafio3.errosNivel == 4)
                {
                    estrelaAmarela1.SetActive(true);
                    estrelaAmarela2.SetActive(false);
                    estrelaAmarela3.SetActive(false);
                }
                break;

            default:
                painelImagem.sprite = imagemPadrao;
                break;
        }
    }
}