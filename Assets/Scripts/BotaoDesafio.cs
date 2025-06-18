using UnityEngine;

public class BotaoDesafio : MonoBehaviour
{
    public int indiceDesafio;
    public AssociadorLibras associador;

    public void OnClick()
    {
        associador.CarregarDesafio(indiceDesafio);
    }
}
