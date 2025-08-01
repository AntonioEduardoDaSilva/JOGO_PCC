using UnityEngine;

public class EmpurrarObjetos : MonoBehaviour
{
    public float forcaEmpurrar = 10f;

    private void OnCollisionStay(Collision colisao)
    {
        Rigidbody rb = colisao.rigidbody;

        // Se o objeto colidido tiver Rigidbody e não estiver travado
        if (rb != null && !rb.isKinematic)
        {
            // Calcula a direção do empurrão (horizontal)
            Vector3 direcao = colisao.transform.position - transform.position;
            direcao.y = 0f; // Não empurra para cima

            // Aplica força no objeto
            rb.AddForce(direcao.normalized * forcaEmpurrar, ForceMode.Force);
        }
    }
    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Empurravel"))
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null && !rb.isKinematic)
        {
            Vector3 direcao = collision.contacts[0].point - transform.position;
            direcao = direcao.normalized;
            rb.AddForce(direcao * 10f, ForceMode.Impulse);
        }
    }
}

}
