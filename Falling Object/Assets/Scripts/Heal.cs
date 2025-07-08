using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool isInsideHeal = false;
    private bool isCoroutineStarted = false;
    [SerializeField] private float heal=1;
    [SerializeField] private PlayerMovementVjezba pmV;
   
    private void OnTriggerEnter(Collider other)
    {
        isInsideHeal = true;     
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideHeal = false;
    }
    private void Update()
    {
        if (isInsideHeal && !isCoroutineStarted && Input.GetKey(KeyCode.F))
        {
            StartCoroutine(DamagePlayer());
            isCoroutineStarted = true;
        }
        if(!isInsideHeal && isCoroutineStarted)
        {
            StopCoroutine(DamagePlayer());
        }
    }
    private IEnumerator DamagePlayer()
    {
        isCoroutineStarted = true;
        pmV.playerHP += heal;
        Debug.Log(pmV.playerHP);
        yield return new WaitForSeconds(1);
        isCoroutineStarted = false;
    }
}
