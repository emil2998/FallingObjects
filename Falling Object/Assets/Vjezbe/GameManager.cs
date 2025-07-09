using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vjezba1_1[] prefab;
    [SerializeField] private float rangeXMin = -3.1f;
    [SerializeField] private float rangeXMax =  3.1f;
   
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
        return Random.Range(rangeXMin, rangeXMax);
    }
    private void Instantiate()
    {
        
        Instantiate(prefab[RandomIndex()], new Vector3(RandomDistanceX(), 6f,-6f), Quaternion.identity);
    }

}
