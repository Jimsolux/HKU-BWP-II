using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI explanationBox;
    public TextMeshProUGUI warningBox;
    public GameObject textBoxBackground;

    public TextMeshProUGUI deathCounter;


    string warning1 = "OUch! Don't get hit by the lazers!";
    private bool warningHasBeenDisplayed = false;


    public List<string> allExplanations;
    public List<string> allWarnings = new List<string>();

    private void Awake()
    {
        allExplanations = new List<string>()
        {
        "You find yourself an unknown, futuristic place. Your head feels miserable, something must have hit it hard.",  //0
        "Use A and D to walk around. Press the Spacebar to jump.", //1
        "To use your magic, click and drag the purple objects to telepathically move them around.",    //2
        "Ohh look, the blocks seem to work as mirrors!",    //3
        "There seems to be a laser receiver there! Try aiming one of the lazers on it!", //4
        "Checkpoint saved!",    //5
        "Use Q and E while dragging an object to rotate the moving Object.",  //6
        "You have made it to the second lair of this complex, good luck!.",  //7
        "Use Z and C To rotate blocks faster.", // 8
        "That looks like a multi-Receiver! It will need two receive two lasers at once to activate.",    //9
        "Hmm it looks like I could hang that up somewhere...",  //10
        "How would I block these two upper lasers..."   //11
        };

        instance = this;
        
        //Empty boxes
        explanationBox.text = " ";
        textBoxBackground.SetActive(false);


        allWarnings.Add(warning1);
    }

    public void DisplayExplanation(int index)
    {
        string value = allExplanations[index];
        explanationBox.text = value;
        textBoxBackground.SetActive(true);
        StartCoroutine("EndDisplayExplanation");
    }

    public IEnumerator EndDisplayExplanation()
    {
        yield return new WaitForSeconds(10); // wait ten seconds and then close display 
        explanationBox.text = " ";
        textBoxBackground.SetActive(false);

    }

    public void DisplayDeaths(int deaths)  
    {
        deathCounter.text = deaths.ToString();
    }

    public void DisplayWarning(int index)
    {

        if (!warningHasBeenDisplayed) { warningBox.text = allWarnings[0]; warningHasBeenDisplayed = true; }
        else
        {
            //string value = allWarnings[index];
            //warningBox.text = value;
            warningHasBeenDisplayed = true;
            StartCoroutine("EndDisplayWarning");
        }

        //textBoxBackground.SetActive(true);
    }

    private IEnumerator EndDisplayWarning()
    {

        yield return new WaitForSeconds(6); // wait two 
        warningBox.text = " ";
    }
    //public void EndDisplayWarning()
    //{
    //    warningBox.text = " ";
    //}
}
