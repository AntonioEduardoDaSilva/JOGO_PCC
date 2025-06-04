using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaNivel1 : MonoBehaviour
{
    // Este método deve ser chamado pelo botão
    public void CarregarNivel1()
    {
        SceneManager.LoadScene("TelaNivel1");
    }
}
