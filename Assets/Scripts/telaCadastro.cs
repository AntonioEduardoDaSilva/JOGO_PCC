using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class telaCadastro : MonoBehaviour
{
    [Header("Campos de Cadastro")]
    public InputField nomeCompletoInput;
    public InputField nomeUsuarioInput;
    public InputField idadeInput;

    [Header("Painéis de Erro")]
    public GameObject painelErroCampos;
    public GameObject painelErroUsuario;
    public GameObject painelErroIdadeNegativa;

    [Header("Painel de Sucesso")]
    public GameObject painelSucesso; // <- novo painel

    public void CadastrarJogador()
    {
        string nome = nomeCompletoInput.text.Trim();
        string usuario = nomeUsuarioInput.text.Trim();
        string idadeStr = idadeInput.text.Trim();

        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(idadeStr))
        {
            painelErroCampos.SetActive(true); return;
        }
        else if (GerenciadorJogadores.instancia.UsuarioExiste(usuario))
        {
            painelErroUsuario.SetActive(true); return;
        }
        else if (!int.TryParse(idadeStr, out int idade) || idade < 0)
        {
            painelErroIdadeNegativa.SetActive(true); return;
        }else {
            Jogador novo = new Jogador(nome, usuario, idade);
        GerenciadorJogadores.instancia.AdicionarJogador(novo);
        }
        painelErroCampos.SetActive(false);
        painelErroUsuario.SetActive(false);
        painelErroIdadeNegativa.SetActive(false);

        StartCoroutine(MostrarPainelSucesso());
    }

    IEnumerator MostrarPainelSucesso()
    {
        painelSucesso.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelSucesso.SetActive(false);
        SceneManager.LoadScene("TelaLogin");
    }

    void Start()
    {
        painelErroCampos.SetActive(false);
        painelErroUsuario.SetActive(false);
        painelErroIdadeNegativa.SetActive(false);
        painelSucesso.SetActive(false); // <- certifique-se que começa desativado
    }
}
