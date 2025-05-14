using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class telaLogin : MonoBehaviour
{
    [Header("Campo de entrada do usuário")]
    public InputField campoUsuario;

    [Header("Painel de erro - não cadastrado")]
    public GameObject painelErroNaocadastrado;

    [Header("Nome da próxima cena")]
    public string nomeDaCenaMenu = "TelaMenu";

    public void FazerLogin()
    {
        painelErroNaocadastrado.SetActive(false);
        string nomeDigitado = campoUsuario.text.Trim();

        if (!GerenciadorJogadores.instancia.UsuarioExiste(nomeDigitado))
        {
            painelErroNaocadastrado.SetActive(true);
            return;
        }

        // Jogador encontrado, você pode armazenar o jogador atual se quiser
        GerenciadorJogadores.instancia.jogadorAtual = GerenciadorJogadores.instancia.ObterJogador(nomeDigitado);

        SceneManager.LoadScene(nomeDaCenaMenu);
    }

    void Start()
    {
        painelErroNaocadastrado.SetActive(false);
    }

    public void irParaTelaMenu()
    {
        SceneManager.LoadScene(nomeDaCenaMenu);
    }

    public void irParaTelaCadastro()
    {
        SceneManager.LoadScene("TelaCadastro");
    }
}
