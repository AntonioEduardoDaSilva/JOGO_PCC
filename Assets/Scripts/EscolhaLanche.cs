using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaLanche : MonoBehaviour
{
    public void EscolherOmelete()
    {
        GameManager.lancheEscolhido = "omelete";
        SceneManager.LoadScene("TelaNivel2");
    }

    public void EscolherPaoComQueijo()
    {
        GameManager.lancheEscolhido = "pao";
        SceneManager.LoadScene("TelaNivel2");
    }

    public void EscolherSaladaDeFrutas()
    {
        GameManager.lancheEscolhido = "salada";
        SceneManager.LoadScene("TelaNivel2");
    }
}
