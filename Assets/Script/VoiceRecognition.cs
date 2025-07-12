using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VoiceRecognition : MonoBehaviour
{
    [SerializeField] GameObject[] _animations;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void callAnimation(string results)
    {
        switch (results)
        {
            case "heart":
                _animations[0].GetComponent<Animator>().enabled = true;
                results = "";
                break;
            case "hard":
                _animations[0].GetComponent<Animator>().enabled = true;
                results = "";
                break;
            case "lungs":
                _animations[1].GetComponent<Animator>().enabled = true;
                results = "";
                break;
            case "skeleton":
                _animations[2].GetComponent<Animator>().enabled = true;
                results = ""; 
                break;
            case "elephant":
                _animations[3].GetComponent<Animator>().enabled = true;
                results = "";
                break;
            case "lion":
                _animations[4].GetComponent<Animator>().enabled = true;
                results = "";
                break;
            case "rhino":
                _animations[5].GetComponent<Animator>().enabled = true;
                results = "";
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
