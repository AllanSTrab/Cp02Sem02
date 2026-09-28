using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    private Vector3 tamanhoOriginal;
    public float multiplicadorTamanho = 2f;
    public float duracao = 5f;

    private bool estaGrande = false;

    void Start()
    {
        tamanhoOriginal = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruta") && !estaGrande)
        {
            Destroy(other.gameObject);
            StartCoroutine(FicarGrande());
        }
    }

    IEnumerator FicarGrande()
    {
        estaGrande = true;

        transform.localScale = tamanhoOriginal * multiplicadorTamanho;

        yield return new WaitForSeconds(duracao);

        transform.localScale = tamanhoOriginal;
        estaGrande = false;
    }
}
