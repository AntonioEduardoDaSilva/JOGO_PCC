using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaIntrodutoria : MonoBehaviour
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
    public void irParaTelaNivel1Introducao()
    {
        SceneManager.LoadScene("Nivel1Introducao");
    }
    public void irParaTelaNivel1()
    {
        SceneManager.LoadScene("TelaNivel1");
    }
}
