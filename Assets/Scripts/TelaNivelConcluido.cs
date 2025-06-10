using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaNivelConcluido : MonoBehaviour
{
    private Jogador jogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jogador = GerenciadorJogadores.instancia.jogadorAtual;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void proximoNivel()
    {
        if (jogador.pontos == 5)
        {
            SceneManager.LoadScene("TelaNivel2");
        }
    }
}
