using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    private static manager global_manager;
    public GameObject monster1;
    public GameObject monster2;
    public TMP_Text winner;
    dataStorage m1_storage;
    dataStorage m2_storage;
    animationControl m1_control;
    animationControl m2_control;
    int game_state; //0:prepare 1:active 2:fighting 

    animationControl[] current_main = new animationControl[2];
    int current_index;

    private void Start()
    {
        game_state = 0;
        m1_storage = monster1.GetComponent<dataStorage>();
        m2_storage = monster2.GetComponent<dataStorage>();
        m1_control = monster1.GetComponentInChildren<animationControl>();
        m2_control = monster2.GetComponentInChildren<animationControl>();
        current_main[0] = m1_control;
        current_main[1] = m2_control;
        current_index = 0;
    }
    public static manager Initiate
    {
        get
        {
            if (global_manager == null)
            {
                global_manager = FindObjectOfType<manager>();
                if (global_manager == null)
                {
                    GameObject _manager = new GameObject("GameManager");
                    global_manager = _manager.AddComponent<manager>();
                }
            }
            return global_manager;
        }
    }

    private void Update()
    {
        if(game_state == 1)
        {
            current_main[current_index].set_state(1);
            current_index++;
            current_index %= 2;
            game_state = 2;
        }

    }
    public void startFight()
    {
        if (m1_storage.get_isReady() && m2_storage.get_isReady())
        {
            game_state = 1;
        }
        else if (!m1_storage.get_isReady())
        {
            m1_storage.set_alarm("I'm not ready!");
        }
        else
        {
            m2_storage.set_alarm("I'm not ready!");
        }
    }

    public void attack(GameObject _from,GameObject _to)
    {
        dataStorage _from_data = _from.GetComponentInParent<dataStorage>();
        dataStorage _to_data = _to.GetComponentInParent<dataStorage>();
        int atk = _from_data.get_atk();
        int def = _to_data.get_def();
        int hp = _to_data.get_hp();
        int new_hp = 0;
        if (atk>def)
        {
            new_hp = hp - (atk - def);
            if(new_hp<=0)
            {
                _to_data.set_hp(0);
                gameover(_from.name+" WIN!");
            }
            else
            {
               _to_data.set_hp(new_hp);
            }
           
        }
    }

    private void gameover(string winner_name)
    {
        winner.text = winner_name;
        set_gameState(0);
    }

    public void set_gameState(int a)
    {
        game_state=a;
    }

    public int get_gameState()
    {
        return game_state;
    }

    public void debugFunc()
    {
        Debug.Log("enter manager.");

        current_main[current_index].set_state(1);
    }
}
