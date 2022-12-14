using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int mysteryCount = 3;

    public ReactiveProperty<bool> mysteryOneResolved = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> mysteryTwoResolved = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> mysteryThreeResolved = new ReactiveProperty<bool>(false);

    public bool Clear { get { return mysteryOneResolved.Value && mysteryTwoResolved.Value && mysteryThreeResolved.Value; } }
}
