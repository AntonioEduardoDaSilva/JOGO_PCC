using UnityEngine;
using UnityEngine.SceneManagement;

public class telaFimJogo : MonoBehaviour
{
    // Chama a cena do nível atual
    public void TentarNovamente()
    {
        if (GerenciadorJogadores.instancia != null && GerenciadorJogadores.instancia.jogadorAtual != null)
        {
            GerenciadorJogadores.instancia.jogadorAtual.ResetarVidas();
        }
        string cenaJogo = PlayerPrefs.GetString("UltimaCena", "TelaNivel1"); // "Nivel1" como fallback
        SceneManager.LoadScene(cenaJogo);
    }

    // Vai para a tela inicial
    public void IrParaTelaInicial()
    {
        SceneManager.LoadScene("TelaInicial"); // Altere "TelaInicial" para o nome real
    }

    // Vai para a seleção de níveis
    public void IrParaTelaDeNiveis()
    {
        SceneManager.LoadScene("TelaNiveis");
    }
}
