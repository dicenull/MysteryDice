using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MysteryThreeChecker : MonoBehaviour
{
    List<Animator> childAnimators = new List<Animator>();
    GameManager manager;
    const string buttonAnimateName = "Enable";
    const int mysteryAnswer = 3;


    public int Digit
    {
        get { return digit.Value; }
    }

    ReactiveProperty<int> digit = new ReactiveProperty<int>(0);

    int button2Digit()
    {
        int buttonNumber = 0;
        int digit = 0;
        foreach (var enabled in childAnimators.Select(child => child.GetBool(buttonAnimateName)))
        {
            int bit = enabled ? 1 : 0;
            buttonNumber += (int)Math.Pow(2, digit) * bit;
            digit++;
        }

        return buttonNumber;
    }

    void updateDigit()
    {
        digit.Value = button2Digit();
    }

    void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        foreach (Transform child in this.transform)
        {
            var animator = child.GetComponent<Animator>();
            childAnimators.Add(animator);

            animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateEnterAsObservable()
                .Subscribe(state =>
                {
                    if (state.StateInfo.IsName("ButtonPopIdle") || state.StateInfo.IsName("ButtonPushIdle"))
                    {
                        updateDigit();
                    }
                }).AddTo(this);
        }

        digit.Subscribe(d =>
        {
            if (d == mysteryAnswer)
            {
                manager.mysteryThreeResolved.Value = true;
            }
        });
    }
}
