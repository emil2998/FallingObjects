using TMPro;
using UnityEngine;

public class GameManagerVjezba : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void ShowDoorText()
    {
        text.gameObject.SetActive(true);
    }

    public void HideDoorText()
    {
        text.gameObject.SetActive(false);
    }
}
