using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PainelDesafio : MonoBehaviour
{
    public GameObject painelDesafio;
    public GameObject sinalPositivo;
    public GameObject sinalNegativo;
    public Button[] botoesResposta;
    public int indiceCorreta = 0;
    public GameObject objetoColetado;
    public TMP_Text pontosTexto;
    public Image[] coracoes;
    public GameObject personagem;
    public GameObject aviao;
    public GameObject espelho;
    public GameObject ioio;
    public GameObject oculos;
    public GameObject urso;
    private Jogador jogador;
    //private bool desafioConcluido = false;
    //private bool desafioConcluido1 = false;
    //private int pontos = 0; 
    private string[] novosTextos;
    private Desafio[] desafios;
    private int indiceDesafioatual = 0;
    public GameObject imagemLetraA;
    public GameObject imagemLetraE;
    public GameObject imagemLetraI;
    public GameObject imagemLetraO;
    public GameObject imagemLetraU;

    void Start()
    {
       desafios = new Desafio[]
        {
            new Desafio(new string[] { "A", "S", "E", "M" }, 0, aviao, imagemLetraA),
            new Desafio(new string[] { "G", "H", "E", "U" }, 2, espelho, imagemLetraE),
            new Desafio(new string[] { "L", "O", "U", "I" }, 3, ioio, imagemLetraI),
            new Desafio(new string[] { "N", "O", "P", "A" }, 1, oculos, imagemLetraO),
            new Desafio(new string[] { "A", "I", "T", "U" }, 3, urso, imagemLetraU)
        };
        painelDesafio.SetActive(false);
        sinalPositivo.SetActive(false);
        sinalNegativo.SetActive(false);
        for (int i = 0; i < desafios.Length; i++)
        {
            if (desafios[i].ImagemDesafio != null)
            {
                desafios[i].ImagemDesafio.SetActive(false);
            }
        }

        jogador = GerenciadorJogadores.instancia.jogadorAtual;

        if (jogador == null)
        {
            Debug.LogError("Jogador atual não encontrado!");
            return;
        }

        AtualizarPontosUI();
        AtualizarCoracoes();
    }
    public void AbrirPainel()
    {
        if (!desafios[indiceDesafioatual].concluido)
        {
            //AtualizarTextosDosBotoes();
            painelDesafio.SetActive(true);
            AtribuirListeners();

            esconderObjetos();
            
        }
    }
   public void AtualizarTextosDosBotoes()
    {
        // Textos definidos localmente aqui
        string[] novosTextos = desafios[indiceDesafioatual].alternativas;

        for (int i = 0; i < botoesResposta.Length; i++)
        {
            if (i < novosTextos.Length)
            {
                TMP_Text textoBotao = botoesResposta[i].GetComponentInChildren<TMP_Text>();
                if (textoBotao != null)
                {
                    textoBotao.text = novosTextos[i];
                }
                else
                {
                    Debug.LogWarning("Botão sem TMP_Text: " + botoesResposta[i].name);
                }
            }
        }
    }
    void esconderObjetos()
    {
        if (personagem != null)
            personagem.SetActive(false);
        if (aviao != null)
            aviao.SetActive(false);
        if (espelho != null)
            espelho.SetActive(false);
        if (oculos != null)
            oculos.SetActive(false);
        if (ioio != null)
            ioio.SetActive(false);
        if (urso != null)
            urso.SetActive(false);
    }
    void mostrarObjetos()
    {
        if (personagem != null)
            personagem.SetActive(true);
        if (aviao != null)
            aviao.SetActive(true);
        if (espelho != null)
            espelho.SetActive(true);
        if (ioio != null)
            ioio.SetActive(true);
        if (oculos != null)
            oculos.SetActive(true);
        if (urso != null)
            urso.SetActive(true);
    }
    public void AtualizarImagem()
    {
        desafios[indiceDesafioatual].ImagemDesafio.SetActive(true);
    }
    void AtribuirListeners()
    {
        AtualizarTextosDosBotoes();
        for (int i = 0; i < botoesResposta.Length; i++)
        {
            int index = i;
            botoesResposta[i].onClick.RemoveAllListeners();
            botoesResposta[i].onClick.AddListener(() => VerificarResposta(index));
        }
    }
    public void VerificarResposta(int indiceEscolhido)
    {
        Debug.Log($"Clique detectado no botão {indiceEscolhido}");

        if (desafios[indiceDesafioatual].concluido || jogador == null) return;

        if (desafios[indiceDesafioatual].indiceCorreto == indiceEscolhido)
        {
            LivroItem itemTeste = new LivroItem
            {
                palavraPortugues = botoesResposta[desafios[indiceDesafioatual].indiceCorreto].GetComponentInChildren<TMP_Text>().text,
                imagem = Resources.Load<Sprite>("Componentes tela nivel 1/aviao"),
                sinalLibras = Resources.Load<Sprite>("Componentes tela nivel 1/sinalAviao"),
                comodoAprendido = "Quarto"
            };
            LivroData.instancia.itensAprendidos.Add(itemTeste);
            jogador.pontos++;
            AtualizarPontosUI();

            if (desafios[indiceDesafioatual].objetoColetado != null)
            {
                desafios[indiceDesafioatual].objetoColetado.SetActive(false);
                Destroy(desafios[indiceDesafioatual].objetoColetado, 0.1f);
            }
            sinalPositivo.SetActive(true);
            Invoke("FecharPainel", 2f);
            desafios[indiceDesafioatual].concluido = true;
            Debug.Log("Resposta correta!");

        }
        else
        {
            jogador.PerderVida();
            AtualizarCoracoes();
            sinalNegativo.SetActive(true);
            Invoke("FecharPainelNegativo", 2f);

            Debug.Log($"Resposta errada! Vidas restantes: {jogador.vidas}");

            if (!jogador.EstaVivo())
            {
                Debug.Log("Game Over!");
                PlayerPrefs.SetString("UltimaCena", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("FimJogo");
            }
        }
    }
    void AtualizarPontosUI()
    {
        if (pontosTexto != null)
        {
            pontosTexto.text = $"PONTOS: {jogador.pontos}";
        }
    }
    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].enabled = (i < jogador.vidas);
        }
    }
    public void mudarDesafio(int id)
    {
        indiceDesafioatual = id;
    }

    void FecharPainel()
    {
        painelDesafio.SetActive(false);
        sinalPositivo.SetActive(false);
        for (int i = 0; i < desafios.Length; i++)
        {
            if (desafios[i].ImagemDesafio != null)
            {
                desafios[i].ImagemDesafio.SetActive(false);
            }
        }
        mostrarObjetos();
    }

    void FecharPainelNegativo()
    {
        sinalNegativo.SetActive(false);
    }
}