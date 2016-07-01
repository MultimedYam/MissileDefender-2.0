using UnityEngine;
using System.Collections;

public class AttackProjectileBehaviour : MonoBehaviour {

    public float setThrust;

    Rigidbody projectileRB;
    public int Desto;

	void Start ()
    {
        StartCoroutine(AccelerateProjectile());
        projectileRB = GetComponent<Rigidbody>();
	}
	
	public IEnumerator AccelerateProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            projectileRB.AddForce(this.transform.forward * setThrust);
        }
    }

    void Update()
    {
        if (gameObject.transform.position.y < 0 || gameObject.transform.position.y > 12)
        {
            Destroy(gameObject);
        }
    }
}
