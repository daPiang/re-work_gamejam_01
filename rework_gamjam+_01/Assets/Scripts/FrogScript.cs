using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //MouseClick and Keyboard Control
        if (other.gameObject.tag == "Player")
        {
            popPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //MouseClick and Keyboard Control
        if (other.gameObject.tag == "Player")
        {
            popPanel.SetActive(false);
        }
    }
    public void ClickInteraction()
    {
        Debug.Log("Clicked");
    }
}