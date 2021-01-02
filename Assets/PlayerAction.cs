using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject sign;
    public bool canActivateThing;
    private Button button;
    public void Action()
    {
        if(canActivateThing)
            button.GetComponent<Animator>().SetTrigger("Click");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Button>())
        {
            canActivateThing = true;
            button = other.gameObject.GetComponent<Button>();
            sign.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Button>())
        {
            canActivateThing = false;
            sign.SetActive(false);
        }
        
    }
}
