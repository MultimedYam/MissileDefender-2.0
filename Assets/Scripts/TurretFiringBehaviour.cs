using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretFiringBehaviour : MonoBehaviour
{
    public List<GameObject> ProjectileArray = new List<GameObject>();
    public List<GameObject> TurretBarrels = new List<GameObject>();
    
    //~~~~~~~~~~~~~~~~
    public GameObject selectedProjectile;
    private int projectileNum;
    private int selectedBarrel = 0;

    //~~~~~~~~~~~~~~~~
    void Start()
    {
        if (ProjectileArray.Count > 0)
        {
            selectedProjectile = ProjectileArray[0];
            projectileNum = 0;
        }
    }

    public void FireProjectile()
    {
        print("Fire");
        Instantiate(selectedProjectile, TurretBarrels[selectedBarrel].transform.position, this.gameObject.transform.rotation);
        //StartCoroutine(JerkBarrel());

        selectedBarrel = (++selectedBarrel) % TurretBarrels.Count;
    }

    public void ChangeProjectile()
    {
        projectileNum = ++projectileNum % ProjectileArray.Count;
        selectedProjectile = ProjectileArray[projectileNum];
        print("Projectile Changed " + projectileNum);
        //listIndex++;
        //if (listIndex >= AvailableMissiles.Count)
        //{
        //    listIndex -= AvailableMissiles.Count;
        //}
        //ActiveMissile = AvailableMissiles[listIndex];

    }
    
    IEnumerator JerkBarrel()
    {
        Vector3 pos = TurretBarrels[selectedBarrel].transform.localPosition;
        for (float timer = 0; timer < 0.4; timer += 0.01f * (Time.deltaTime * 100))
        {
            yield return new WaitForSeconds(0.01f);

            TurretBarrels[selectedBarrel].transform.localPosition = Vector3.Lerp(pos, new Vector3(pos.x, pos.y, pos.z - 0.25f), Time.deltaTime);
        }

        for (float timer = 0; timer < 0.6; timer += 0.01f * (Time.deltaTime * 100))
        {
            yield return new WaitForSeconds(0.01f);
            
            TurretBarrels[selectedBarrel].transform.localPosition = Vector3.Lerp(TurretBarrels[selectedBarrel].transform.localPosition, pos, Time.deltaTime);
        }
    }
}
