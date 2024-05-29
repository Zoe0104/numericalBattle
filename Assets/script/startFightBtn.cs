using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startFightBtn : MonoBehaviour
{
    public Button startBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(startFight);
    }

    void startFight()
    {
        Debug.Log("pressed start");
        //manager.Initiate.debugFunc();
        manager.Initiate.startFight();
    }
}
