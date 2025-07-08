using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private GameManagerVjezba manager;
    private bool isInsideTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        manager.ShowDoorText();
      
    }
    private void OnTriggerExit(Collider other)
    {
        manager.HideDoorText();
        isInsideTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isInsideTrigger = true;      
    }

    private void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.E) && isInsideTrigger)
        {
            if (this.transform.rotation.y != 0f)
            {
                this.transform.Rotate(0f, -90f, 0f);
            }
            else
            {
                this.transform.Rotate(0f, 90f, 0f);
            }
        }
    }
}
