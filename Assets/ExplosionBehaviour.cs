using UnityEngine;
using System.Collections;

public class ExplosionBehaviour : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float ExpansionTime = 4.0f;
    [Range(0.0f, 10.0f)]
    public float RetractionTime = 3.0f;
    public int ExplosionSize = 5;

    private float refreshInterval = 0.01f;
    private Vector3 shrinkSize = Vector3.one * 1;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(expandOverTime());
    }

    IEnumerator expandOverTime()
    {
        for (float timer = 0; timer < ExpansionTime; timer += refreshInterval * (Time.deltaTime * (1 / refreshInterval)))
        {
            yield return new WaitForSeconds(1f / 100f);

            this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one * ExplosionSize, Time.deltaTime);
            //new Vector3(0.1f, 0.1f, 0.1f) * (Time.deltaTime * 100);
        }
        StartCoroutine(shrinkOverTime());
    }

    IEnumerator shrinkOverTime()
    {
        for (float timer = 0; timer < RetractionTime; timer += refreshInterval * (Time.deltaTime * (1 / refreshInterval)))
        {
            yield return new WaitForSeconds(1f / 100f);

            this.transform.localScale = Vector3.Lerp(this.transform.localScale, shrinkSize, Time.deltaTime);
            //new Vector3(0.1f, 0.1f, 0.1f) * (Time.deltaTime * 100);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }
}
