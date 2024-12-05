using System.Collections.Generic;
using UnityEngine;

public class AvoidSameWord : MonoBehaviour
{
    List<string> lastValues = new List<string>();

    void Start()
    {
        lastValues.Add("nada");
    }

    public bool CheckRepeatedWord(string currentWord)
    {
        if (lastValues.Count <= 1) return false;

        if (lastValues.Contains(currentWord))
        {
            Debug.Log("Palavra repetida! Mudando de palavra...");
            return true; 
        }

        return false;
    }

    public bool AddWord(string palavra)
    {
        if (!CheckRepeatedWord(palavra))
        {
            lastValues.Add(palavra); 
            RemoveFromList(); 
            return true;
        }
        return false;
    }

    public void RemoveFromList()
    {
        if (lastValues.Count > 12)
        {
            lastValues.RemoveAt(0);
        }
    }
}
