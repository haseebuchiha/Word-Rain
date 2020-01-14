using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string word;
    private string alphabet;

    private int atIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        word = word.ToUpper();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCorrect();
        }
    }

    void isCorrect(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
            alphabet = hit.transform.name;
            // Debug.Log("i hit" + alphabet);

            if(alphabet[0].ToString() == word[atIndex].ToString()){
                Debug.Log("sahi ponche o: " + alphabet);
                atIndex++;
            }
            else{
                Debug.Log("nai bhai aese nai: " + alphabet);
            }
        }
    }
}