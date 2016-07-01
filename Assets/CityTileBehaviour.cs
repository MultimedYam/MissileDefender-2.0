using UnityEngine;
using System.Collections;

public class CityTileBehaviour : MonoBehaviour
{
    public GameObject GM;
    public GameObject AI;

    void Start()
    {
        GM = GameObject.Find("Game Manager");
        AI = GameObject.Find("AI");
    }

    void OnTriggerEnter(Collider other)
    {
        AI.GetComponent<AIBehaviour>().OnMissileHit(other.GetComponent<AttackProjectileBehaviour>().Desto);
        Debug.Log(other.ToString() + " city hit");
        GetComponent<Animation>().Play();
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        do
        {
            yield return null;
        }
        while (GetComponent<Animation>().isPlaying);
        GM.GetComponent<GameActions>().Cities.Remove(this.gameObject);

        Destroy(this.gameObject);
    }

}
