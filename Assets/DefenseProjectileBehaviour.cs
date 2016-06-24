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
    private Vector3 target;
    private Rigidbody rb;

    void Start()
    {
        StartCoroutine(AccelerateMissile(Thrust));

        rb = this.gameObject.GetComponent<Rigidbody>();
        origin = transform.position;
    }

    /*void Update()
	{
		if (target != null)
		{
			rotation = Quaternion.LookRotation(target - transform.position);
			this.transform.LookAt(target, Vector3.back);
		}
	}*/

    //public void SetOrigin(Vector3 _origin)
    //{
    //    origin = _origin;
    //    rb = this.gameObject.GetComponent<Rigidbody>();
    //}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ExplosionSphere")
        {
            this.Explode();
        }
    }

    public IEnumerator AccelerateMissile(int setThrust)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / 100f);
            distanceTravelled = Vector3.Distance(origin, this.transform.position);

            rb.AddForce(this.transform.forward * setThrust);

            if (distanceTravelled > DistanceToExplode)
            {
                Explode();
            }
        }
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    public void Explode()
    {
        Instantiate(ExplosionSphere, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
