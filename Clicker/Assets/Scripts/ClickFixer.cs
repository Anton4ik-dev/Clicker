using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickFixer : MonoBehaviour
{
    [SerializeField] private AudioSource mainTheme;
    [SerializeField] private float money, rep;
    [SerializeField] private TextMeshProUGUI moneyTmp, repTmp;
    private float moneyScaler = 1, repScaler = 1, delay;
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
    private void Start()
    {
        ChangeText("money");
        ChangeText("rep");
        mainTheme.Play();
        mainTheme.Pause();
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
            mainTheme.Pause();
    }
    public void AddMoney()
    {
        delay = 1;
        mainTheme.UnPause();
        money += moneyScaler;
        ChangeText("money");
        AddRep();
    }
    private void AddRep()
    {
        repLimitation++;
        if (repLimitation == 10)
        {
            rep += repScaler;
            ChangeText("rep");
            repLimitation = 0;
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
}