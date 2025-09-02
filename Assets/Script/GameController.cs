using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int TargerSuccess;
    int InstantSuccess;
    int selectedNumber;
    
    GameObject selectedButton;
    GameObject currentButton;
    
    public AudioSource[] voices;
    public GameObject[] buttons;
    public TextMeshProUGUI counter;
    public GameObject[] endGamePanels;
    
    float TotalTime = 10;
    float Minute;
    float Second;
    bool Timer;
    
    void Start()
    {
        selectedNumber = 0;
        Timer = true;
    }
    
    void Update()
    {
        if (Timer && TotalTime > 1)
        {
            TotalTime -= Time.deltaTime;
            Minute = Mathf.FloorToInt(TotalTime / 60);
            Second = Mathf.FloorToInt(TotalTime % 60);
        
            //counter.text = Mathf.FloorToInt(TotalTime).ToString();
            counter.text = string.Format("{0:00}:{1:00}", Minute, Second);
        }
        else
        {
            counter.text = "Süre Bitti";
            Timer = false;
            GameOver();
        }
        
    }

    public Sprite defultSprite;

    public void giveObject(GameObject myObject)
    {
        currentButton = myObject;
        currentButton.GetComponent<Image>().sprite = currentButton.GetComponentInChildren<SpriteRenderer>().sprite;
        currentButton.GetComponent<Image>().raycastTarget = false;
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
            selectedButton = currentButton;
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
            InstantSuccess++;
            selectedButton.GetComponent<Image>().enabled = false;
            currentButton.GetComponent<Image>().enabled = false;
            selectedButton.GetComponent<Button>().enabled= false;
            currentButton.GetComponent<Button>().enabled = false;
            selectedNumber = 0;
            selectedButton = null;
            SetButtonsActiveState(true);

            if (TargerSuccess == InstantSuccess)
            {
                Win();
            }
        }
        else
        {
            voices[2].Play();
            selectedButton.GetComponent<Image>().sprite = defultSprite;
            currentButton.GetComponent<Image>().sprite = defultSprite;
            selectedNumber = 0;
            selectedButton = null;
            SetButtonsActiveState(true);
        }
    }

    void GameOver()
    {
        endGamePanels[0].SetActive(true);
    }

    void Win()
    {
        endGamePanels[1].SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
