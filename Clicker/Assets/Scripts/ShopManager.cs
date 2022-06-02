using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    private Object[] _slotsData;
    private SlotsSO[] _slotsSO;
    [SerializeField] private Transform _instrumentsContentPanel, _musiciansContentPanel, _agitationsContentPanel, _drugsContentPanel;
    [SerializeField] private GameObject _itemSlot;
    [SerializeField] private Transform guitarist, barabanshik, bas;
    private float _heightSize;
    [SerializeField] private ClickFixer clicker;
    private void Awake()
    {
        _heightSize = -_itemSlot.GetComponent<RectTransform>().sizeDelta.y + 10;
        FillArrayAndSort();
        FillPanel();
    }
    private void FillArrayAndSort()
    {
        _slotsData = Resources.LoadAll("Slots", typeof(SlotsSO));
        _slotsSO = new SlotsSO[_slotsData.Length];
        for (int i = 0; i < _slotsData.Length; i++)
        {
            _slotsSO[i] = (SlotsSO)_slotsData[i];
        }
        SlotsSO temp;
        for (int i = 0; i < _slotsSO.Length; i++)
        {
            for (int j = i+1; j < _slotsSO.Length; j++)
            {
                if(_slotsSO[i].slotCost > _slotsSO[j].slotCost)
                {
                    temp = _slotsSO[i];
                    _slotsSO[i] = _slotsSO[j];
                    _slotsSO[j] = temp;
                }
            }
        }
    }
    private void FillPanel()
    {
        for (int i = 0; i < _slotsSO.Length; i++)
        {
            int n = i;
            Transform slotCopy = _itemSlot.transform;
            switch (_slotsSO[i].typeOfSlot.ToString())
            {
                case "instrument":
                    slotCopy = Instantiate(_itemSlot, _instrumentsContentPanel).transform;
                    if (_slotsSO[i].typeOfMusician.ToString() != "guitarist")
                    {
                        slotCopy.gameObject.SetActive(false);
                    } else
                    {
                        _instrumentsContentPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, _heightSize);
                    }
                    slotCopy.GetChild(0).GetComponent<Button>().onClick.AddListener(() => BuySlotInstrument(slotCopy, _slotsSO[n]));
                    break;
                case "musician":
                    _musiciansContentPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, _heightSize);
                    slotCopy = Instantiate(_itemSlot, _musiciansContentPanel).transform;
                    slotCopy.GetChild(0).GetComponent<Button>().onClick.AddListener(() => BuySlotMusician(slotCopy, _slotsSO[n]));
                    break;
                case "agitation":
                    _agitationsContentPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, _heightSize);
                    slotCopy = Instantiate(_itemSlot, _agitationsContentPanel).transform;
                    slotCopy.GetChild(0).GetComponent<Button>().onClick.AddListener(() => BuySlotAgitation(slotCopy, _slotsSO[n]));
                    break;
                case "drug":
                    _drugsContentPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, _heightSize);
                    slotCopy = Instantiate(_itemSlot, _drugsContentPanel).transform;
                    slotCopy.GetChild(0).GetComponent<Button>().onClick.AddListener(() => BuySlotDrugs(slotCopy, _slotsSO[n]));
                    break;
            }
            slotCopy.GetChild(1).GetComponent<Image>().sprite = _slotsSO[i].slotSprite;
            slotCopy.GetChild(2).GetComponent<TextMeshProUGUI>().text = _slotsSO[i].slotName;
            slotCopy.GetChild(3).GetComponent<TextMeshProUGUI>().text = _slotsSO[i].slotCost.ToString();
            slotCopy.GetChild(4).GetComponent<TextMeshProUGUI>().text = _slotsSO[i].slotBustDiscription;            
            slotCopy.GetChild(5).GetComponent<TextMeshProUGUI>().text = _slotsSO[i].typeOfMusician.ToString();            
        }
    }
    private void BuySlotInstrument(Transform slot, SlotsSO so)
    {
        if (clicker.Money >= so.slotCost)
        {
            clicker.Money -= so.slotCost;
            clicker.MoneyScaler += so.slotChangeValues[0];
            clicker.ChangeText("money");
            DisableSlot(slot);
        }
    }
    private void BuySlotMusician(Transform slot, SlotsSO so)
    {
        if(clicker.Rep >= so.slotCost)
        {
            clicker.Rep -= so.slotCost;
            clicker.MoneyScaler += so.slotChangeValues[0];
            clicker.RepScaler += so.slotChangeValues[1];
            CheckMusician(so);
            TurnOnInstruments(so.typeOfMusician.ToString());
            clicker.ChangeText("money");
            clicker.ChangeText("rep");
            DisableSlot(slot);
        }
    }
    private void BuySlotAgitation(Transform slot, SlotsSO so)
    {
        if (clicker.Money >= so.slotCost)
        {
            clicker.Money -= so.slotCost;
            clicker.Rep += so.slotChangeValues[0];
            clicker.ChangeText("money");
            clicker.ChangeText("rep");
            DisableSlot(slot);
        }
    }
    private void BuySlotDrugs(Transform slot, SlotsSO so)
    {
        if (clicker.Money >= so.slotCost)
        {
            clicker.Money -= so.slotCost;
            clicker.MoneyScaler += so.slotChangeValues[0];
            clicker.RepScaler += so.slotChangeValues[1];
            clicker.ChangeText("money");
            DisableSlot(slot);
        }
    }
    private void DisableSlot(Transform slot)
    {
        slot.parent.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, _heightSize);
        Destroy(slot.gameObject);
    }
    private void CheckMusician(SlotsSO so)
    {
        switch(so.typeOfMusician.ToString())
        {
            case "guitarist":
                guitarist.gameObject.SetActive(true);
                guitarist.GetComponent<Image>().sprite = so.slotSprite;
                break;
            case "baraban":
                barabanshik.gameObject.SetActive(true);
                barabanshik.GetComponent<Image>().sprite = so.slotSprite;
                break;
            case "bas":
                bas.gameObject.SetActive(true);
                bas.GetComponent<Image>().sprite = so.slotSprite;
                break;
        }
    }
    public void TurnOnInstruments(string whatKind)
    {
        for (int i = 0; i < _instrumentsContentPanel.childCount; i++)
        {
            if(_instrumentsContentPanel.GetChild(i).GetChild(5).GetComponent<TextMeshProUGUI>().text == whatKind)
            {
                _instrumentsContentPanel.GetChild(i).gameObject.SetActive(true);
                _instrumentsContentPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, _heightSize);
            }
        }
    }
}