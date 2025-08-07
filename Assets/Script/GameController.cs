using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int selectedNumber;
    GameObject selectedButton;
    GameObject theButtonItself;

    void Start()
    {
        selectedNumber = 0;
    }

    public Sprite defultSprite;

    public void giveObject(GameObject myObject)
    {
        theButtonItself = myObject;
        theButtonItself.GetComponent<Image>().sprite = theButtonItself.GetComponentInChildren<SpriteRenderer>().sprite;
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
        yield return new WaitForSeconds(1);

        if (selectedNumber == IncomingValue)
        {
            Destroy(selectedButton.gameObject);
            Destroy(theButtonItself.gameObject);
            
            selectedNumber = 0;
            selectedButton = null;
        }
        else
        {
            selectedButton.GetComponent<Image>().sprite = defultSprite;
            theButtonItself.GetComponent<Image>().sprite = defultSprite;

            selectedNumber = 0;
            selectedButton = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
