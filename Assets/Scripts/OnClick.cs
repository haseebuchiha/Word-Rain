using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    private GameObject tapped;
    public static bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start method in onclick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("imside on mouse down");
        isClicked = true;
        Debug.Log("is clicked = " + isClicked);
        
        // get the object tapped and then destroy
        tapped = gameObject;

        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
    }

    public GameObject GetObject()
    {
        return tapped;
    }

    public bool ClickStatus()
    {
        Debug.Log("ClickStatus = " + isClicked);
        return isClicked;
    }

    public void SetClickStatus(bool status) // so that game controller can set status false again after receiving status true
    {
        isClicked = status;
    }
}
