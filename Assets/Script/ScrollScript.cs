using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScrollScript : MonoBehaviour
{

    public List<GameObject> objectItem;
    public List<string> objectText;
    public List<AudioSource> _audio;
    public TextMeshProUGUI infoText;
    public List<Sprite> soundIcon;
    public Image soundBtn;

    int scrolling = 0;
    bool audioStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void Selection()
    {
        foreach (GameObject items in objectItem)
        {
            items.SetActive(false);
        }
        objectItem[scrolling].SetActive(true);
      //  infoText.text = objectText[scrolling];
        scrolling++;
    }

    public void MuteAudio()
    {
        if (audioStatus == false)
        {
            muteAudio(true);
            soundBtn.sprite = soundIcon[0];
            audioStatus = true;
        }
        else
        {
            muteAudio(false);
            audioStatus = false;
            soundBtn.sprite = soundIcon[1];
        }
      
        
    }
    void muteAudio(bool mute)
    {
        foreach (AudioSource items in _audio)
        {
            items.mute = mute;
        }
    }
}
