using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaNivel1 : MonoBehaviour
{
    public GameObject cadeadoNivel2;
    private Jogador jogador;

    void Start()
    {
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
    }
    void Update()
    {
        proximoNivel();
    }
    // Este método deve ser chamado pelo botão
    public void CarregarNivel1()
    {
        SceneManager.LoadScene("TelaNivel1");
    }
    public void proximoNivel()
    {
        if (jogador.pontos == 5)
        {
            cadeadoNivel2.SetActive(false);
        }
    }
}
