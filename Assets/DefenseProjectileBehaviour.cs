using UnityEngine;
using System.Collections;

public class DefenseProjectileBehaviour : MonoBehaviour {

    public GameObject ExplosionSphere;
    [Range(0f, 100f)]
    public float DistanceToExplode = 50f;
    [Range(1, 10
        )]
    public int Thrust;
    
    public Quaternion rotation;

    private float distanceTravelled;
    private Vector3 origin;
    public Rigidbody rb;

    void Start()
    {

        rb = this.gameObject.GetComponent<Rigidbody>();

        StartCoroutine(AccelerateMissile(Thrust));
        origin = transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "ExplosionSphere")
        {
            this.Explode();
        }
    }

    public IEnumerator AccelerateMissile(int setThrust)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f/100f);
            
            distanceTravelled = Vector3.Distance(origin, this.transform.position);

            rb.AddForce(this.transform.forward * setThrust);
            if (distanceTravelled > DistanceToExplode)
            {
                Explode();
            }
        }
    }


    public void Explode()
    {
        Instantiate(ExplosionSphere, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
