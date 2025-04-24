using UnityEngine;

public class ObjetoAnimado : MonoBehaviour
{
    public float velocidadRotacion = 50f;
    public float intervaloMovimiento = 2f;
    public float distanciaMovimiento = 1f;
    private float tiempoTranscurrido = 0f;

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        // ⏱️ ROTACIÓN constante
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);

        // 🔄 ESCALADO oscilante con Mathf.Sin
        float factorEscala = 0.3f * Mathf.Sin(Time.time) + 1f; // valor entre 0.7 y 1.3
        transform.localScale = escalaOriginal * factorEscala;

        // 🎲 TRASLACIÓN aleatoria por X o Y cada cierto tiempo
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= intervaloMovimiento)
        {
            Vector3 direccion = Vector3.zero;

            if (Random.value > 0.5f)
                direccion = Vector3.right;
            else
                direccion = Vector3.up;

            transform.Translate(direccion * distanciaMovimiento);
            tiempoTranscurrido = 0f;
        }
    }
}
