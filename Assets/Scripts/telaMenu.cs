using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class telaMenu : MonoBehaviour
{
    public GameObject painel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void irParaTelaIntrodutoria()
    {
        SceneManager.LoadScene("TelaIntrodutoria");
    }
    public void irParaTelaIncial()
    {
        SceneManager.LoadScene("TelaInicial");
    }
    public void irParaLivroInterativo()
    {
        SceneManager.LoadScene("LivroInterativo");
    }
    public void irParaTrelaMenu()
    {
        SceneManager.LoadScene("TelaMenu");
    }

}
