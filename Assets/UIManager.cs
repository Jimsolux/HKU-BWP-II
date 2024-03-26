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
        "You find yourself an unknown, futuristic place. Your head feels miserable, something must have hit it hard.",
        "Use WASD to walk around. Press the Spacebar to jump.",
        "To use your magic, click and drag objects to telepathically move them around.",
        "Ohh look, they are mirrors!",
        "Use Q and E while dragging an object to rotate the moving Object.",
        "There looks to be a laser receiver there! Try aiming one of the lazers on it!"
        };

        instance = this;
        EndDisplayExplanation();


        allWarnings.Add(warning1);
       //allExplanations.Add(explanation1);
    }

    public void DisplayExplanation(int index)
    {
        string value = allExplanations[index];
        explanationBox.text = value;
        textBoxBackground.SetActive(true);
    }

    public void EndDisplayExplanation()
    {
        explanationBox.text = " ";
        textBoxBackground.SetActive(false);
    }

    public void DisplayDeaths(int deaths)   // Call to update
    {
        deathCounter.text = deaths.ToString();
    }

    public void DisplayWarning(int index)
    {

        if (!warningHasBeenDisplayed) warningBox.text = allWarnings[0];
        else
        {
        string value = allWarnings[index];
        warningBox.text = value;
        }

        //textBoxBackground.SetActive(true);
    }
}
