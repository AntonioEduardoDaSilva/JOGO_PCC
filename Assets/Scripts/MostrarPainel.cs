using UnityEngine;

public class MostrarPainel : MonoBehaviour
{
    public GameObject painelDesafio;

    void Start()
    {
        if (painelDesafio != null)
            painelDesafio.SetActive(false);
    }

    public void Mostrar()
    {
        if (painelDesafio != null)
            painelDesafio.SetActive(true);
    }
}
