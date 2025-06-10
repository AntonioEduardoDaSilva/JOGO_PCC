using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssociadorLibras : MonoBehaviour
{
    [System.Serializable]
    public class Par
    {
        public Button botaoSinal;
        public string letraCorreta; // exemplo: "M"
        public bool acertou = false;
    }

    public Par[] pares; // Conecte os sinais aqui
    public Button[] botoesLetra; // Conecte os botões M, E, S, A
    public GameObject painelErro;

    private Par sinalSelecionado = null;

    void Start()
    {
        painelErro.SetActive(false);
        foreach (Par par in pares)
        {
            par.botaoSinal.onClick.AddListener(() => SelecionarSinal(par));
        }

        foreach (Button letra in botoesLetra)
        {
            letra.onClick.AddListener(() => VerificarLetra(letra));
        }

    }

    void SelecionarSinal(Par par)
    {
        if (par.acertou) return;

        sinalSelecionado = par;

        // Exemplo visual (opcional): destaque o botão selecionado
        foreach (Par p in pares)
            p.botaoSinal.image.color = Color.white;

        par.botaoSinal.image.color = Color.yellow;
    }

    void VerificarLetra(Button botaoLetra)
    {
        if (sinalSelecionado == null) return;

        string letraClicada = botaoLetra.GetComponentInChildren<TextMeshProUGUI>().text;

        if (sinalSelecionado.letraCorreta == letraClicada)
        {
            // Correto
            sinalSelecionado.acertou = true;
            sinalSelecionado.botaoSinal.interactable = false;
            botaoLetra.interactable = false;

            // Mudar cor para indicar acerto
            sinalSelecionado.botaoSinal.image.color = Color.green;
            botaoLetra.image.color = Color.green;
        }
        else
        {
            // Incorreto
            StartCoroutine(MostrarPainelErro());
            sinalSelecionado.botaoSinal.image.color = Color.white;
        }

        sinalSelecionado = null;
    }

    System.Collections.IEnumerator MostrarPainelErro()
    {
        painelErro.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        painelErro.SetActive(false);
    }
}
