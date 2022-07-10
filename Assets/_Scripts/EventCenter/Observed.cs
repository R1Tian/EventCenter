using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observed : MonoBehaviour
{
    private void Start()
    {
        EventCenter.Instance.triggerEvent<string>("PlayerDead", "Ming");
    }
}
