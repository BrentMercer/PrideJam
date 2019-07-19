using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxColorTester : MonoBehaviour
{

    public GameObject StackPlatform;
    public Text OnScreenTime;
    public DesiredBlock desiredBlock;
    public GameTimer gameTimer;
    public GameObject LevelPassedPanel;
    public GameObject GameOverPanel;
    public AudioSource audioCorrect;
    public AudioSource audioIncorrect;
    public AudioSource audioWinLevel;
    private string Block;
    private int CurrentLevel;

    private void Start()
    {
        CurrentLevel = 1;
        desiredBlock.CurrentDesiredBlock = "Purple";
        gameTimer.ResetTimer();
        gameTimer.StartCount();
    }

    public void Update()
    {
        gameTimer.Timer -= gameTimer.CountBy * Time.deltaTime;
        OnScreenTime.text = Mathf.Round(gameTimer.Timer).ToString();
        if (gameTimer.Timer <= 0 )
        {
            ResetGame();
        }
    }

    private IEnumerator levelEndDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == desiredBlock.CurrentDesiredBlock)
        {
            Debug.Log("we got desiredBlock");
            Block = other.tag;
            switch (Block)
            {
                case "Purple":
                    TriggerPurple();
                    break;
                case "Blue":
                    TriggerBlue();
                    break;
                case "Green":
                    TriggerGreen();
                    break;
                case "Yellow":
                    TriggerYellow();
                    break;
                case "Orange":
                    TriggerOrange();
                    break;
                case "Red":
                    TriggerRed();
                    break;
            }
        }
        else 
        {
            other.transform.localPosition = other.GetComponent<CurrentHomeLocation>().homeLocation;
            audioIncorrect.Play();
        }
    }

    private void TriggerPurple()
    {
        //StackPlatform.transform.Translate(0, -1, 0);
        //transform.localPosition = new Vector3(0, 0, 0);
        BlockList[0].transform.localPosition = new Vector3(-32.0f, -9.0f, 0);
        BlockList[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        audioCorrect.Play();
        desiredBlock.CurrentDesiredBlock = "Blue";
    }

    private void TriggerBlue()
    {
        //StackPlatform.transform.Translate(0, -1, 0);
        BlockList[1].transform.localPosition = new Vector3(-28.0f, -9.0f, 0);
        BlockList[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        audioCorrect.Play();
        desiredBlock.CurrentDesiredBlock = "Green";
    }

    private void TriggerGreen()
    {
        //StackPlatform.transform.Translate(0, -1, 0);
        BlockList[2].transform.localPosition = new Vector3(-24.0f, -9.0f, 0);
        BlockList[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        audioCorrect.Play();
        desiredBlock.CurrentDesiredBlock = "Yellow";
    }

    private void TriggerYellow()
    {
        //StackPlatform.transform.Translate(0, -1, 0);
        BlockList[3].transform.localPosition = new Vector3(-20.0f, -9.0f, 0);
        BlockList[3].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        audioCorrect.Play();
        desiredBlock.CurrentDesiredBlock = "Orange";
    }

    private void TriggerOrange()
    {
        //StackPlatform.transform.Translate(0, -1, 0);
        BlockList[4].transform.localPosition = new Vector3(-16.0f, -9.0f, 0);
        BlockList[4].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        audioCorrect.Play();
        desiredBlock.CurrentDesiredBlock = "Red";
    }

    private void TriggerRed()
    {
        // this will reset the stack platform object to its original position so we will need to change this based on where we decide to put it 
        //StackPlatform.transform.position = new Vector3(0, -4.5f, 0);
        BlockList[5].transform.localPosition = new Vector3(-12.0f, -9.0f, 0);
        BlockList[5].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        desiredBlock.CurrentDesiredBlock = "Purple";
        audioWinLevel.Play();
        StartCoroutine(levelEndDelay());
        //ResetLevel();
    }

    public List<GameObject> BlockList;
    public List<Vector3> LocationList;
    [HideInInspector]
    public List<Vector3> UsedLocationList;

    private int LocationListLength = 6;
    private int CurrentLocation;
    private int ReplacingListLocationsNum = 6;
    
    private void ResetGame()
    {
        CurrentLevel = 1;
        GameOverPanel.SetActive(true);
        gameTimer.StopCount();
        gameTimer.ResetTimer();
       
    }

    private Vector3 NewLocation;
    private void ResetLevel()
    {
        
        gameTimer.StopCount();
        gameTimer.NextLevelTimer(CurrentLevel);
        LevelPassedPanel.SetActive(true);
        LocationListLength = 6;
        CurrentLevel += 1;
        foreach (var GameObject in BlockList)
        {
            
            CurrentLocation = Random.Range(0, LocationListLength);
            Debug.Log("LocationList = " + LocationList[CurrentLocation]);
            GameObject.GetComponent<CurrentHomeLocation>().homeLocation = LocationList[CurrentLocation];
            GameObject.transform.position = LocationList[CurrentLocation];
            UsedLocationList.Add(LocationList[CurrentLocation]);
            LocationList.Remove(LocationList[CurrentLocation]);
           
            
            LocationListLength-=1;
        }
        ReplacingListLocationsNum = 5;
        foreach(var Location in UsedLocationList)
        {
            LocationList.Add(UsedLocationList[ReplacingListLocationsNum]);
           
                ReplacingListLocationsNum -= 1;
           
            
        }
        
    }
}
