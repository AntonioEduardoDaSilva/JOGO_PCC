using UnityEngine;

public class ControlaIngredientes : MonoBehaviour
{
    public GameObject[] ingredientesOmelete;
    public GameObject[] ingredientesPao;
    public GameObject[] ingredientesSalada;
    public GameObject ovo;
    public GameObject uva;
    public GameObject maca;
    public GameObject pao;
    public GameObject manteiga;
    public GameObject kiwi;
    public GameObject tomate;
    public GameObject queijo;

    void Start()
    {
        // Desativar todos primeiro
        DesativarTodos();
        esconderObjetos();
        GameObject[] botoes = GameObject.FindGameObjectsWithTag("BotaoColetar");

        foreach (GameObject botao in botoes)
        {
            botao.SetActive(false);
        }

        // Ativar somente os ingredientes do lanche escolhido
        switch (GameManager.lancheEscolhido)
        {
            case "omelete":
                AtivarIngredientes(ingredientesOmelete);
                ovo.SetActive(true);
                manteiga.SetActive(true);
                tomate.SetActive(true);
                break;
            case "pao":
                AtivarIngredientes(ingredientesPao);
                pao.SetActive(true);
                queijo.SetActive(true);
                manteiga.SetActive(true);
                break;
            case "salada":
                AtivarIngredientes(ingredientesSalada);
                kiwi.SetActive(true);
                maca.SetActive(true);
                uva.SetActive(true);
                break;
        }
    }
    void esconderObjetos()
    {
        if (ovo != null)
            ovo.SetActive(false);
        if (pao != null)
            pao.SetActive(false);
        if (queijo != null)
            queijo.SetActive(false);
        if (tomate != null)
            tomate.SetActive(false);
        if (manteiga != null)
            manteiga.SetActive(false);
        if (maca != null)
            maca.SetActive(false);
        if (kiwi != null)
            kiwi.SetActive(false);
        if (uva != null)
            uva.SetActive(false);
    }

    void DesativarTodos()
    {
        AtivarIngredientes(ingredientesOmelete, false);
        AtivarIngredientes(ingredientesPao, false);
        AtivarIngredientes(ingredientesSalada, false);
    }

    void AtivarIngredientes(GameObject[] ingredientes, bool ativar = true)
    {
        foreach (GameObject item in ingredientes)
        {
            if (item != null)
                item.SetActive(ativar);
        }
    }
}
