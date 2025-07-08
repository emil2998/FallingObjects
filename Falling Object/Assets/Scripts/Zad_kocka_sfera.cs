using UnityEngine;

public class Zad_kocka_sfera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SphereCollider sphere))
        {
            Debug.Log("Sfera je usla u kocku");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SphereCollider sphere))
        {
            Debug.Log("Sfera je u kocki");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out SphereCollider sphere))
        {
            Debug.Log("Sfera je izasla iz kocke");
        }
    }

}
