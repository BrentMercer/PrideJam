﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxColorTester : MonoBehaviour
{
    
    public GameObject StackPlatform;
    public Text OnScreenTime;
    public DesiredBlock desiredBlock;
    public GameTimer gameTimer;
    public GameObject LevelPassedPanel;
    public GameObject GameOverPanel;
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
    private void OnTriggerEnter(Collider other)
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
          other.transform.position = other.GetComponent<CurrentHomeLocation>().HomeLocation;
        }
       
    }

    private void TriggerPurple()
    {

        StackPlatform.transform.Translate(0, -1, 0);
        desiredBlock.CurrentDesiredBlock = "Blue";
    }
    private void TriggerBlue()
    {

        StackPlatform.transform.Translate(0, -1, 0);
        desiredBlock.CurrentDesiredBlock = "Green";
    }
    private void TriggerGreen()
    {

        StackPlatform.transform.Translate(0, -1, 0);
        desiredBlock.CurrentDesiredBlock = "Yellow";
    }
    private void TriggerYellow()
    {

        StackPlatform.transform.Translate(0, -1, 0);
        desiredBlock.CurrentDesiredBlock = "Orange";
    }
    private void TriggerOrange()
    {

        StackPlatform.transform.Translate(0, -1, 0);
        desiredBlock.CurrentDesiredBlock = "Red";
    }
    private void TriggerRed()
    {
        // this will reset the stack platform object to its original position so we will need to change this based on where we decide to put it 
        StackPlatform.transform.position = new Vector3(0, -4.5f, 0);
        desiredBlock.CurrentDesiredBlock = "Purple";
        ResetLevel();
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
            GameObject.GetComponent<CurrentHomeLocation>().HomeLocation = LocationList[CurrentLocation];
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
