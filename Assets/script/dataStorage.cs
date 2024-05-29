using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class dataStorage : MonoBehaviour
{
    public TMP_InputField hp;
    public TMP_InputField def;
    public TMP_InputField atk;
    public Button acc;
    public TMP_Text alarm;
    private int _hp;
    private int _def;
    private int _atk;
    private bool _isReady;

    // Start is called before the first frame update
    void Start()
    {
        _isReady = false;
        acc.onClick.AddListener(StoreInput);
    }

    void StoreInput()
    {
        bool hp_tem = int.TryParse(hp.text, out _hp);
        bool def_tem = int.TryParse(def.text, out _def);
        bool atk_tem = int.TryParse(atk.text, out _atk);
        if (hp_tem && def_tem && atk_tem)
        {
            if (_hp>0 && _def>=0 && _atk>=0)
            {
                _isReady = true;
                alarm.text = "I'm ready!";
            }
            else
            {
                _isReady=false;
                alarm.text = "positive number, Please.";
            }
            
        }
        else
        {
            _isReady = false;
            alarm.text = "Enter INTEGER please.";
        }    
    }
    
    public bool get_isReady()
    { return _isReady; }

    public void set_alarm(string content)
    {
        alarm.text = content;
    }

    public int get_hp()
    { return _hp; }
    public int get_def()
    { return _def; }
    public int get_atk()
    { return _atk; }
    public void set_hp(int new_hp)
    {
        _hp= new_hp;
        hp.text = new_hp.ToString();
    }
}
