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
    private Object[] spritesForBack;
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
    private void Start()
    {
        spritesForBack = Resources.LoadAll("Themes", typeof(Sprite));
        ChangeText("money");
        ChangeText("rep");
        mainTheme.Play();
        mainTheme.Pause();
    }
    private void Update()
    {
        
    }
    public void AddMoney()
    {
        AudioManagerScript.delay = 1.5f;
        mainTheme.UnPause();
        money += moneyScaler;
        ChangeText("money");
        AddRep();
        //ChangePos();
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
        if(rep >= 110)
        {
            for (int i = 0; i < managerButtons.Length; i++)
            {
                managerButtons[i].GetComponent<Image>().color = Color.white;
                managerButtons[i].GetComponent<Button>().interactable = true;
            }
            //Sprite m_sprite = (Sprite)spritesForBack[1];
            //gameObject.GetComponent<Image>().sprite = m_sprite;
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