using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vjezba1_1[] prefab;

    private int RandomIndex()
    {
        int randomIndex = Random.Range(0, prefab.Length);
        return randomIndex;
    }
 
    private void Start()
    {
        StartCoroutine(StartSpawns());
    }
   

    private IEnumerator StartSpawns()
    {
        yield return new WaitForSeconds(1);
        Instantiate();

        StartCoroutine(StartSpawns());

    }
    private float RandomDistanceX()
    {
        return Random.Range(-7, 8);
    }
    private void Instantiate()
    {
        
        Instantiate(prefab[RandomIndex()], new Vector3(RandomDistanceX(), 8f,0), Quaternion.identity);
    }

}
