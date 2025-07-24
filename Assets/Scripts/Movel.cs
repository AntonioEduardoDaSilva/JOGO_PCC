using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Movel : MonoBehaviour
{
    public string nomeMovel;
    public Sprite imagemLibras;
    public Sprite imagemDoObjeto;
    public VideoClip videoLibras; // vídeo do sinal em Libras
    public RenderTexture renderTexture; // textura para exibir o vídeo
    public Vector3 offsetLateral = new Vector3(2f, 0f, 0f); // posição relativa ao móvel

    [HideInInspector] public bool foiRespondido = false;
    private GameObject videoQuad; // guarda referência do quad criado (evita duplicação)

    // Mostra o vídeo ao lado do móvel (no mundo)
    public void MostrarLibrasAoLado()
    {
        // Evita recriar o mesmo vídeo várias vezes
        if (videoQuad != null)
        {
            videoQuad.SetActive(true);
            return;
        }

        if (videoLibras != null && renderTexture != null)
        {
            Debug.Log("Mostrando vídeo Libras ao lado de: " + nomeMovel);

            // Criar plano (Quad) para o vídeo
            videoQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            videoQuad.name = "VideoQuad_" + nomeMovel;
            videoQuad.transform.position = transform.position + offsetLateral;

            // Ajustar escala para proporção vertical (ex: 9:16)
            videoQuad.transform.localScale = new Vector3(1f, 1.78f, 1f); // 9:16 = 0.5625 ratio, invertido = 1.78

            // Criar e configurar VideoPlayer
            VideoPlayer videoPlayer = videoQuad.AddComponent<VideoPlayer>();
            videoPlayer.clip = videoLibras;
            videoPlayer.renderMode = VideoRenderMode.RenderTexture;
            videoPlayer.targetTexture = renderTexture;
            videoPlayer.isLooping = true;
            videoPlayer.playOnAwake = false;

            // Aplicar RenderTexture no material
            Material mat = new Material(Shader.Find("Unlit/Texture"));
            mat.mainTexture = renderTexture;
            videoQuad.GetComponent<MeshRenderer>().material = mat;

            videoPlayer.Prepare();
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Vídeo ou RenderTexture não atribuído! Usando imagem estática.");

            // Fallback: Mostrar sprite ao lado do móvel
            GameObject img = new GameObject("Libras_" + nomeMovel);
            SpriteRenderer sr = img.AddComponent<SpriteRenderer>();
            sr.sprite = imagemLibras;
            img.transform.position = transform.position + offsetLateral;
            sr.sortingLayerName = "Default";
            sr.sortingOrder = 10;
            img.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        }
    }

    public void MostrarLibrasUI(Transform painelUI)
    {
        if (videoLibras != null && renderTexture != null)
        {
            GameObject videoGO = new GameObject("VideoLibras_" + nomeMovel, typeof(RectTransform));
            videoGO.transform.SetParent(painelUI, false);

            RawImage rawImage = videoGO.AddComponent<RawImage>();
            rawImage.rectTransform.anchoredPosition = new Vector2(100, 0);
            rawImage.rectTransform.sizeDelta = new Vector2(300, 500); // proporção vertical (9:16)
            rawImage.texture = renderTexture;

            GameObject videoPlayerGO = new GameObject("VideoPlayer_" + nomeMovel);
            videoPlayerGO.transform.SetParent(videoGO.transform, false);

            VideoPlayer videoPlayer = videoPlayerGO.AddComponent<VideoPlayer>();
            videoPlayer.clip = videoLibras;
            videoPlayer.renderMode = VideoRenderMode.RenderTexture;
            videoPlayer.targetTexture = renderTexture;
            videoPlayer.isLooping = true;
            videoPlayer.playOnAwake = false;

            videoPlayer.Prepare();
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Vídeo ou RenderTexture não atribuído! Usando imagem estática.");

            GameObject novaImagem = new GameObject("ImagemLibras", typeof(RectTransform));
            novaImagem.transform.SetParent(painelUI, false);

            Image img = novaImagem.AddComponent<Image>();
            img.sprite = imagemLibras;
            img.rectTransform.anchoredPosition = new Vector2(100, 0);
        }
    }
}
