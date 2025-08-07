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
        //Debug.Log("Evet, Tıkladı: Gelen değer : " + value);

        if (selectedNumber == 0)
        {
            selectedNumber = value;
        }
        else
        {
            if (selectedNumber == value)
            {
                Debug.Log("Bir eşleşme gerçekleşti !");
                selectedNumber = 0;
            }
            else
            {
                Debug.Log("Eşleşmedi !");
                selectedNumber = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
