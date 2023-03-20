using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private Key.KeyType key;
    [SerializeField] private string _sceneName;

    public Key.KeyType GetKeyType()
    {
        return key;
    }

    public void OpenGate()
    {
        LevelManager.Instance.LoadScene(_sceneName);
    }
}
