using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CarregarImagemPorURL : MonoBehaviour
{
    public RawImage rawImage;
    public string url = "https://i.postimg.cc/15014dNT/Group-61.png";

    void Start()
    {
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        Debug.Log("Iniciando carregamento da imagem...");
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Imagem carregada com sucesso.");
            Texture2D textura = DownloadHandlerTexture.GetContent(request);
            rawImage.texture = textura;
        }
        else
        {
            Debug.LogError("Erro ao carregar imagem: " + request.error);
        }
    }
}
