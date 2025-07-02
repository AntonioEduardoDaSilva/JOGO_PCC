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
