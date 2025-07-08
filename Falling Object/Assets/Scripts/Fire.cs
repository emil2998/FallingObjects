using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isInsideFire = false;
    private bool isCoroutineStarted = false;
    [SerializeField] private float damage=2;
    [SerializeField] private PlayerMovementVjezba pmV;
   
    private void OnTriggerEnter(Collider other)
    {
        isInsideFire = true;     
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideFire = false;
    }
    private void Update()
    {
        if (isInsideFire && !isCoroutineStarted)
        {
            StartCoroutine(DamagePlayer());
            isCoroutineStarted = true;
        }
        if(!isInsideFire && isCoroutineStarted)
        {
            StopCoroutine(DamagePlayer());
        }
    }
    private IEnumerator DamagePlayer()
    {
        isCoroutineStarted = true;
        pmV.playerHP -= damage;
        Debug.Log(pmV.playerHP);
        yield return new WaitForSeconds(1);
        isCoroutineStarted = false;
    }
}
