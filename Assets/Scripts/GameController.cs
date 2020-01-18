using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string[] words;
    private string alphabet; // the alphabet caught in the game
    private string currentWord; // the current word displaying in the game

    private int atWord = 0;
    private int atIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentWord = words[atWord]; // set the current word once
        currentWord = currentWord.ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if left mouse button is clicked
        {
           Check();
        }
    }

    void Check(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // throw ray from screen at mouse position, into scene
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
            alphabet = hit.transform.name;
            
            if(!alphabet.Equals("floor")){ // destroy any object that was hit, except floor. Don't wanna destroy the floor
                Destroy(hit.transform.gameObject);
            }

            if(alphabet[0].ToString() == currentWord[atIndex].ToString()){ // check if alphabet we clicked is same as alphabet we want
                Debug.Log("sahi ponche o: " + alphabet);
                atIndex++;

                if(atIndex == currentWord.Length){ // calls for next word
                    atIndex = 0;
                    atWord++;
                }

                if(atWord == words.Length){
                    Debug.Log("Game khatam");
                    SceneManager.LoadScene("MainMenu");
                }
                else{
                    SetNextWord(); // if words have not been completed. Continue with next word
                }
            }
            else{
                Debug.Log("nai bhai aese nai: " + alphabet);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    void SetNextWord(){
        currentWord = words[atWord];
        currentWord = currentWord.ToUpper();
    }
}