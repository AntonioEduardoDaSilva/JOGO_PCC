using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class telaMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void irParaTelaNiveis()
    {
        SceneManager.LoadScene("TelaNiveis");
    }
    public void irParaTelaIncial()
    {
        SceneManager.LoadScene("TelaInicial");
    }
    public void irParaLivroInterativo()
    {
        SceneManager.LoadScene("LivroInterativo");
    }

}
