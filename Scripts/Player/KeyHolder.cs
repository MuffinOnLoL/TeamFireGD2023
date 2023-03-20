using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
   private List<Key.KeyType> keyList;
   [SerializeField] private GameObject _accessText;
   [SerializeField] private int _numKeysNeeded;
   private AudioSource[] sounds;
   private AudioSource keyCollect;


   private void Awake()
   {
    keyList = new List<Key.KeyType>();
    _accessText.SetActive(false);
    sounds = GetComponents<AudioSource> ();
    keyCollect = sounds[1];
   }
   
   public void AddKey(Key.KeyType keyType)
   {
    Debug.Log("Added key: " + keyType);
    keyList.Add(keyType);
   }

   public void RemoveKey(Key.KeyType keyType)
   {
    keyList.Clear();
   }

   public bool ContainsKey(Key.KeyType keyType)
   {
    return keyList.Contains(keyType);
   }

   private void OnTriggerEnter(Collider other) 
   {
    Key key = other.GetComponent<Key>();
    if (key != null)
    {
        AddKey(key.GetKeyType());
        keyCollect.Play(0);
        Destroy(key.gameObject);
    }

    Gate accessGate = other.GetComponent<Gate>();
    if (accessGate != null)
    {
        if (ContainsKey(accessGate.GetKeyType()) && keyList.Count == _numKeysNeeded)
        {
            RemoveKey(accessGate.GetKeyType());
            accessGate.OpenGate();
        }
        else
        {
            _accessText.SetActive(true);
            StartCoroutine(DisplayText());
        }

    }
   }

   public IEnumerator DisplayText() 
   {
    yield return new WaitForSeconds(3f);
    _accessText.SetActive(false);
   }
}
