using UnityEngine;
using System.Collections;

public class AttackProjectileBehaviour : MonoBehaviour {

    public float setThrust;

    Rigidbody projectileRB;

	void Start ()
    {
        StartCoroutine(AccelerateProjectile());
        projectileRB = GetComponent<Rigidbody>();
	}
	
	public IEnumerator AccelerateProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / 100f);
            projectileRB.AddForce(this.transform.forward * setThrust);
        }
    }

    void Update()
    {
        if (gameObject.transform.position.y < 0 || gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "Structure")
        {
            print("Collided");
            Destroy(collision.gameObject);
        }
    }
}
