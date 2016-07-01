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
        Instantiate(selectedProjectile, TurretBarrels[selectedBarrel].transform.position, this.gameObject.transform.rotation);

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
}
