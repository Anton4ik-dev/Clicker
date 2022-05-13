using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickFixer : MonoBehaviour
{
    [SerializeField] private float money;
    [SerializeField] private TextMeshProUGUI moneyTmp;
    [SerializeField] private TextMeshProUGUI repTmp;
    private float rep, moneyScaler, repScaler;
    private int repLimitation;
    private Object[] instrumentsData, musiciansData, agitationsData;

    private void Start()
    {
        ChangeText(moneyTmp, "money");
        ChangeText(repTmp, "rep");
        instrumentsData = Resources.LoadAll("Instruments", typeof(InstrumentSO));
        musiciansData = Resources.LoadAll("Musicians", typeof(MusicianSO));
        agitationsData = Resources.LoadAll("Agitations", typeof(AgitationSO));
    }
    public void AddMoney()
    {
        money += 1 + moneyScaler;
        ChangeText(moneyTmp, "money");
        AddRep();
    }
    private void AddRep()
    {
        repLimitation++;
        if (repLimitation == 10)
        {
            rep += 1 + repScaler;
            ChangeText(repTmp, "rep");
            repLimitation = 0;
        }
    }
    private void ChangeText(TextMeshProUGUI changing, string whichText)
    {
        switch(whichText) 
        {
            case "money" : 
                changing.text = "Money: " + money;
                break;
            case "rep":
                changing.text = "Reputation: " + rep;
                break;
        }
    }
}