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
}
