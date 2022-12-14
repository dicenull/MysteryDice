using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;

public class GameClearChecker : MonoBehaviour
{
    GameManager manager;
    Transform dice;
    private bool isCleared = false;

    void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        dice = GameObject.Find("mystery_dice").transform;

        this.UpdateAsObservable().Subscribe(_ =>
        {
            if (manager.Clear)
            {
                clearAction();
            }
        });
    }

    void clearAction()
    {
        isCleared = true;

        Destroy(dice.gameObject);
    }
}
