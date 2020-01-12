using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string word;

    private int atIndex = 0;

    private List<GameObject> letterObjects = new List<GameObject>();

    private bool Clicked = false;

    private GameObject objectClicked;

    private SpawnGameObjects spawnGameObjects;
    private OnClick onClickObject = new OnClick()  ;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("inside start");
        word = word.ToLower();

        FillObjectsList();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("inside update");

        Clicked = onClickObject.ClickStatus();
        Debug.Log("value of clicked is sexful      =  " + Clicked);
        
        
        if (Clicked)
        {
            // update the statuses
            onClickObject.SetClickStatus(false);
            Debug.Log("update main hon mission sexful");
            Clicked = false;

            //get the object clicked and compare
            objectClicked = onClickObject.GetObject();

            if (!isCorrect())
            {
                Debug.Log("Incorrect!");
            }
        }
    }

    void FillObjectsList() // get the relevant game objects from spawner.
    {
        Debug.Log("Fill object method ");

        GameObject go;
        foreach(char c in word)
        {
          //  go = (GameObject)spawnGameObjects.GetGameObject((int)c - 97);

           //  letterObjects.Add(go);
        }
    }

    bool isCorrect()
    {
        if (objectClicked == letterObjects[atIndex])
        {
            atIndex++;
            return true;
        }

        return false;
    }
}
