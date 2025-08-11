using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int selectedNumber;
    GameObject selectedButton;
    GameObject theButtonItself;
    public AudioSource[] voices;
    public GameObject[] buttons;

    void Start()
    {
        selectedNumber = 0;
    }

    public Sprite defultSprite;

    public void giveObject(GameObject myObject)
    {
        theButtonItself = myObject;
        theButtonItself.GetComponent<Image>().sprite = theButtonItself.GetComponentInChildren<SpriteRenderer>().sprite;
        theButtonItself.GetComponent<Image>().raycastTarget = false;
        voices[1].Play();
    }

    void SetButtonsActiveState(bool state)
    {
        foreach(var item in buttons)
        {
            if (item != null)
            {
                item.GetComponent<Image>().raycastTarget = state;
            }
        }
    }

    public void ButtonClicked(int value)
    {
        Controls(value);
    }

    void Controls(int IncomingValue)
    {
        if (selectedNumber == 0)
        {
            selectedNumber = IncomingValue;
            selectedButton = theButtonItself;
        }
        else
        {
            StartCoroutine(CheckMatchWithDelay(IncomingValue));
        }
    }

    IEnumerator CheckMatchWithDelay(int IncomingValue)
    {
        SetButtonsActiveState(false);
        yield return new WaitForSeconds(1);

        if (selectedNumber == IncomingValue)
        {
            selectedButton.GetComponent<Image>().enabled = false;
            theButtonItself.GetComponent<Image>().enabled = false;
            selectedButton.GetComponent<Button>().enabled= false;
            theButtonItself.GetComponent<Button>().enabled = false;
            selectedNumber = 0;
            selectedButton = null;
            SetButtonsActiveState(true);
        }
        else
        {
            voices[2].Play();
            selectedButton.GetComponent<Image>().sprite = defultSprite;
            theButtonItself.GetComponent<Image>().sprite = defultSprite;
            selectedNumber = 0;
            selectedButton = null;
            SetButtonsActiveState(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
