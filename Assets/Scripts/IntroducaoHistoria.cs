using System.Collections;
using UnityEngine;
using TMPro;

public class IntroducaoHistoria : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    [TextArea(3, 10)]
    public string textoHistoria;
    public float velocidade = 0.05f;

    void Start()
    {
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        textoUI.text = "";
        foreach (char letra in textoHistoria)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidade);
        }

        // Opcional: esperar um tempo e depois ocultar o texto ou carregar cena
        yield return new WaitForSeconds(2f);
        // gameObject.SetActive(false); // Oculta
        // SceneManager.LoadScene("NomeDaCena"); // Carrega outra cena
    }
}
