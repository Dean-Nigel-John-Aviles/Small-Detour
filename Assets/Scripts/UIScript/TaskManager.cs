using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject PlayerUIPanel;

    [Header("For End Triggers")]
    public EndTrigger endTrigger;
    public bool firstET;
    public bool secondET;
    public bool thirdET;

    [Header("Enemy Bool")]
    public bool slimeText = false;
    public bool rabbitText = false;
    public bool cultText = false;
    public bool grabbitText = false;
    public bool fourthTask = false;

    [Header("Enemy Number")]
    public int slimeNum = 0;
    public int rabbitNum = 0;
    public int GrabbitNum = 0;
    public int cultNum = 0;

    [Header("Task Panel")]
    public GameObject FirstTask;
    public GameObject SecondTask;
    public GameObject ThirdTask;
    public GameObject FourthTask;

    [Header("Task Text")]
    public Text txtSlimeTask;
    public Text txtRabbitTask;
    public Text txtGRabbitTask;
    public Text txtCultTask;

    public int totalSlimeNeeded;
    public int totalRabbitNeeded;
    public int totalGRabbitNeeded;
    public int totalCultNeeded;

    private void Start()
    {
        firstET = true;
        secondET = false;
        thirdET = false;

        PlayerUIPanel.SetActive(true);
        Time.timeScale = 1;
    }

    private void Update()
    {
        endtriggers();

        //For Enemies Task
        if (slimeText == true)
        {
            SlimeText();
        }

        if (rabbitText == true)
        {
            RabbitText();
        }

        if (grabbitText == true)
        {
            GRabbitText();
        }

        if (fourthTask == true)
        {
            FourthTask.SetActive(true);
        }

        if (cultText == true)
        {
            CultText();
        }
    }

    private void endtriggers() 
    {
        if (firstET == true)
        {
            endTrigger = GameObject.Find("FirstEndTrigger").GetComponent<EndTrigger>();
        }
        else if (secondET == true)
        {
            endTrigger = GameObject.Find("SecondEndTrigger").GetComponent<EndTrigger>();
        }
        else if (thirdET == true)
        {
            endTrigger = GameObject.Find("ThirdEndTrigger").GetComponent<EndTrigger>();
        }
        else
        {
            Debug.Log("Wews Mali ka nanaman boi");
        }
    }

    //Chapter 1
    private void SlimeText()
    {
        int remainingSlime = totalSlimeNeeded - slimeNum;
        txtSlimeTask.text = "• Defeat the Enchanted Slime (" + slimeNum + "/" + totalSlimeNeeded + ")";
        if (slimeNum >= totalSlimeNeeded)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(false);
            ThirdTask.SetActive(false);
            FourthTask.SetActive(false);
            endTrigger.Ok = true;

            if (firstET == true)
            {
                secondET = true;
                firstET = false;
                thirdET = false;

                endtriggers();
            }
            else if (secondET == true)
            {
                thirdET = true;
                firstET = false;
                secondET = false;
                endtriggers();
            }
            else if (thirdET == true) 
            {
                Debug.Log("Oh wow amazing!");
            }
            slimeText = false;
        }
    }

    private void RabbitText()
    {
        int remainingRabbit = totalRabbitNeeded - rabbitNum;
        txtRabbitTask.text = "• Defeat the Malevolent Rabbits (" + rabbitNum + "/" + totalRabbitNeeded + ")";
        if (rabbitNum >= totalRabbitNeeded)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(false);
            ThirdTask.SetActive(false);
            FourthTask.SetActive(false);
            endTrigger.Ok = true;

            if (firstET == true)
            {
                secondET = true;
                firstET = false;
                thirdET = false;
                endtriggers();
            }
            else if (secondET == true)
            {
                thirdET = true;
                firstET = false;
                secondET = false;
                endtriggers();
            }
            else if (thirdET == true)
            {
                Debug.Log("Oh wow amazing!");
            }
            rabbitText = false;
        }
    }

    private void GRabbitText()
    {
        int remainingGRabbit = totalGRabbitNeeded - GrabbitNum;
        txtGRabbitTask.text = "• Defeat the Giant Malevolent Rabbits (" + GrabbitNum + "/" + totalGRabbitNeeded + ")";
        if (GrabbitNum >= totalGRabbitNeeded)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(false);
            ThirdTask.SetActive(false);
            FourthTask.SetActive(false);
            endTrigger.Ok = true;

            if (firstET == true)
            {
                secondET = true;
                firstET = false;
                thirdET = false;
                endtriggers();
            }
            else if (secondET == true)
            {
                thirdET = true;
                firstET = false;
                secondET = false;
                endtriggers();
            }
            else if (thirdET == true)
            {
                Debug.Log("Oh wow amazing!");
            }
            grabbitText = false;
        }
    }


    //Chapter 2
    private void CultText()
    {
        int remainingCult = totalCultNeeded - cultNum;
        txtCultTask.text = "Dark Cult Eliminated (" + cultNum + "/" + totalCultNeeded + ")";
        if (cultNum >= totalCultNeeded)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(false);
            ThirdTask.SetActive(false);
            FourthTask.SetActive(false);
            endTrigger.Ok = true;

            if (firstET == true)
            {
                secondET = true;
                firstET = false;
                thirdET = false;
                endtriggers();
            }
            else if (secondET == true)
            {
                thirdET = true;
                firstET = false;
                secondET = false;
                endtriggers();
            }
            else if (thirdET == true) 
            {
                Debug.Log("Oh wow amazing!");
            }
            cultText = false;
        }
    }
}
