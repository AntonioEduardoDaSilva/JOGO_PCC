using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaIntrodutoria : MonoBehaviour
{
    public GameObject painelEscolherLanche;
    public painelDesafio2 desafio;
    public bool isSalada = false;
    public bool isOmelete = false;
    public bool isPao = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelEscolherLanche.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void mostrarEscolherLanche()
    {
        painelEscolherLanche.SetActive(true);
    }
    public void nivel2Omelete()
    {
        SceneManager.LoadScene("TelaNivel2");
    }
    public void nivel2PaoQueijo()
    {
        SceneManager.LoadScene("TelaNivel2");
    }
    public void nivel2SaladaFrutas()
    {
        SceneManager.LoadScene("TelaNivel2");
        Destroy(desafio.ovo);
    }
    public void irParaTelaNiveis()
    {
        SceneManager.LoadScene("TelaNiveis");
    }
    public void irParaTelaNivel1Introducao()
    {
        SceneManager.LoadScene("Nivel1Introducao");
    }
    public void irParaTelaNivel2Introducao()
    {
        SceneManager.LoadScene("Nivel2Introducao");
    }
    public void irParaTelaNivel3Introducao()
    {
        SceneManager.LoadScene("Nivel3Introducao");
    }
    public void irParaTelaNivel1()
    {
        SceneManager.LoadScene("TelaNivel1");
    }
    public void irParaTelaNivel2()
    {
        SceneManager.LoadScene("TelaNivel2");
    }
    public void irParaTelaNivel3()
    {
        SceneManager.LoadScene("TelaNivel3");
    }
}
