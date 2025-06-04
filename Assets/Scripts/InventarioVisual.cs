using UnityEngine;
using UnityEngine.UI;

public class InventarioVisual : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab do item coletado
    public Transform painelColetados; // Painel onde os itens serão adicionados

    // Chame este método quando o jogador coletar um item
    public void AdicionarItem(Sprite iconeItem)
    {
        GameObject novoItem = Instantiate(itemPrefab, painelColetados);
        Image imagem = novoItem.GetComponent<Image>();
        if (imagem != null)
        {
            imagem.sprite = iconeItem;
        }
    }
}
