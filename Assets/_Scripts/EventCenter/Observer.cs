using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : MonoBehaviour
{
    private void Awake()
    {
        EventCenter.Instance.RegistEvent<string>("PlayerDead", OnPlayerDead);
    }

    private void OnPlayerDead(string name)
    {
        Debug.Log(name +" À¿¡À");
    }
}
