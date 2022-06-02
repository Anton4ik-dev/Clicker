using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClickFixer : MonoBehaviour
{
    [SerializeField] private AudioSource mainTheme;
    [SerializeField] private float money, rep;
    [SerializeField] private TextMeshProUGUI moneyTmp, repTmp;
    [SerializeField] private GameObject[] managerButtons = new GameObject[3];
    [SerializeField] private GameObject managerInfo;
    [SerializeField] private float winningCondMoney, winningCondRep, karmaLimit;
    [SerializeField] private float chastotaRep, menegerOpenedValue;
    private float karma = 0;
    private bool eventHappened = true;
    private float moneyScaler = 1, repScaler = 1;
    private int repLimitation;
    public float MoneyScaler
    {
        get { return moneyScaler; }
        set { moneyScaler = value; }
    }
    public float RepScaler
    {
        get { return repScaler; }
        set { repScaler = value; }
    }
    public float Rep
    {
        get { return rep; }
        set { rep = value; }
    }
    public float Money
    {
        get { return money; }
        set { money = value; }
    }
    public float Karma
    {
        get { return karma; }
        set { karma = value; }
    }
    private void Start()
    {
        ChangeText("money");
        ChangeText("rep");
        mainTheme.Play();
        mainTheme.Pause();
    }
    public void AddMoney()
    {
        AudioManagerScript.delay = 1.5f;
        mainTheme.UnPause();
        money += moneyScaler;
        ChangeText("money");
        AddRep();
        if(winningCondMoney <= money && winningCondRep <= rep)
        {
            if(karma < karmaLimit)
            {
                //good
            } else
            {
                //bad
            }
        }
        //ChangePos();
    }
    private void AddRep()
    {
        repLimitation++;
        if (repLimitation == chastotaRep)
        {
            rep += repScaler;
            ChangeText("rep");
            repLimitation = 0;
        }
        if(rep >= menegerOpenedValue && eventHappened)
        {
            eventHappened = false;
            managerInfo.SetActive(true);
            Destroy(managerInfo, 5);
            for (int i = 0; i < managerButtons.Length; i++)
            {
                managerButtons[i].GetComponent<Image>().color = Color.white;
                managerButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }
    public void ChangeText(string whichText)
    {
        switch(whichText) 
        {
            case "money" : 
                moneyTmp.text = "Money: " + money;
                break;
            case "rep":
                repTmp.text = "Reputation: " + rep;
                break;
        }
    }
    private void ChangePos()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-885.0f, 885.0f), Random.Range(-425.0f, 425.0f), 0);
    }
}