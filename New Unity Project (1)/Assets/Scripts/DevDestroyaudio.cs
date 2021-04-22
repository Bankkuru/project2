using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevDestroyaudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
