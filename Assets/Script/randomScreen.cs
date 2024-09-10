using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class randomScreen : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject[] prefabList;
    public int length;
    public GameObject currentScreen;
    private GameObject[] sideScreens;


    private int numberOne;
    private int numberTwo;
    private int numberThree;
    private System.Random genereator;

    // Start is called before the first frame update
    void Start()
    {
        this.sideScreens = new GameObject[3];

        genereator = new System.Random();

        this.numberOne = genereator.Next(length);
        this.numberTwo = genereator.Next(length);
        this.numberThree = genereator.Next(length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 0.2f), Quaternion.identity);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 0.2f), Quaternion.identity);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 0.2f), Quaternion.identity);
    }

    public void Switchto(int number)
    {
        GameObject temp = currentScreen;

        switch (number)
        {
            case 0:
                this.currentScreen = this.sideScreens[0];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[1], true);
                DestroyImmediate(this.sideScreens[2], true);
                this.icons[2].SetActive(false);
                this.icons[0].SetActive(true);
                break;
            case 1:
                this.currentScreen = this.sideScreens[1];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[0], true);
                DestroyImmediate(this.sideScreens[2], true);
                this.icons[2].SetActive(true);
                this.icons[1].SetActive(true);
                this.icons[0].SetActive(true);
                break;
            case 2:
                this.currentScreen = this.sideScreens[2];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[1], true);
                DestroyImmediate(this.sideScreens[0], true);
                this.icons[2].SetActive(true);
                this.icons[0].SetActive(false);
                break;
        }

        this.numberOne = genereator.Next(length);
        this.numberTwo = genereator.Next(length);
        this.numberThree = genereator.Next(length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 0.5f), Quaternion.identity);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 0.5f), Quaternion.identity);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 0.5f), Quaternion.identity);
    }

    public void MoveScreen(Vector3 position)
    {
        this.currentScreen.transform.position = position;
    }

    public void SetScreenBehind(int number)
    {
        switch (number)
        {
            case 0:
                this.sideScreens[1].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[0].transform.position = new Vector3(0, 0, 0.2f);
                break;
            case 1:
                this.sideScreens[0].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[1].transform.position = new Vector3(0, 0, 0.2f);
                break;
            case 2:
                this.sideScreens[0].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[1].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 0.2f);
                break;
        }
    }

}