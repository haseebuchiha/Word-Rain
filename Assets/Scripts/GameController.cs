using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string[] words;
    private string alphabet; // the alphabet caught in the game
    private string currentWord; // the current word displaying in the game

    private int atWord = 0;
    private int atIndex = 0;
    public static int score = 0;

    public Text wordTextDisplay; // to dislpay the current word

    private Damage damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = FindObjectOfType<Damage>();

        score = 0;

        currentWord = words[atWord]; // set the current word once
        currentWord = currentWord.ToUpper();

        wordTextDisplay.text = currentWord; 
    }

    // Update is called once per frame
    void Update()
    {
        // if(ifMissed()){
        //     RoundOver();
        // }

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
                
                atIndex++;
                score+=1; // add 1 score for each right alphabet clicked

                if(atIndex == currentWord.Length){ // calls for next word
                    atIndex = 0;
                    atWord++;
                    score+=10; // add 10 score for each whole word
                }

                if(atWord == words.Length){
                    RoundOver();
                }
                else{
                    SetNextWord(); // if words have not been completed. Continue with next word
                }
            }
            else{
                RoundOver();
            }
        }
    }

    void SetNextWord(){
        currentWord = words[atWord];
        currentWord = currentWord.ToUpper();

        wordTextDisplay.text = currentWord;
    }

    void RoundOver(){
        SceneManager.LoadScene("RoundOverScene");
    }

    // bool ifMissed(){ // check if the required alphabet was missed
    //     Debug.Log("gameControllerscript alphabet: " + currentWord[atIndex].ToString());
    //     if(damage.GetCollidedObjectName() == currentWord[atIndex].ToString()){
    //         return true;
    //     }
    //     return false;
    // }
}