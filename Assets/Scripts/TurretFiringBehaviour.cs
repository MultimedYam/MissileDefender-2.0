using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretFiringBehaviour : MonoBehaviour
{
    public List<GameObject> ProjectileArray = new List<GameObject>();
    public List<GameObject> TurretBarrels = new List<GameObject>();
    
    //~~~~~~~~~~~~~~~~
    private GameObject selectedProjectile;
    private int selectedBarrel = 0;

    //~~~~~~~~~~~~~~~~
    void Start()
    {
        if (ProjectileArray.Count > 0)
        {
            selectedProjectile = ProjectileArray[0];
        }
    }

    public void FireProjectile()
    {
        print("Fire");
        Instantiate(selectedProjectile, TurretBarrels[selectedBarrel].transform.position, this.gameObject.transform.rotation);
        selectedBarrel = (++selectedBarrel) % TurretBarrels.Count;
    }

    public void ChangeProjectile()
    {
        //listIndex++;
        //if (listIndex >= AvailableMissiles.Count)
        //{
        //    listIndex -= AvailableMissiles.Count;
        //}
        //ActiveMissile = AvailableMissiles[listIndex];
    }
    
}
