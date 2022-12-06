using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int misteryCount = 6;

    public ReactiveProperty<bool> mysteryOneResolved = new ReactiveProperty<bool>(false);
}
