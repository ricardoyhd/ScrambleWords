using System.Collections.Generic;
using UnityEngine;

public class Pilha : MonoBehaviour
{
    [SerializeField] private Stack<char> pilha = new Stack<char>();

    public bool Empilhar(char valor, string currentWord)
    {
        if (!Cheia())
        {   
            Debug.Log(valor);
            Debug.Log(currentWord);
            if(valor == currentWord[pilha.Count])
            {
                pilha.Push(valor);
                return true;
            } 
        }
        return false;
    }

    public void LimparPilha()
    {
        while (!Vazia())
        {
            pilha.Pop();
        }
        Debug.Log("Pilha vazia");
    }

    public bool Vazia()
    {
        return pilha.Count == 0;
    }
    public bool Cheia()
    {
        return pilha.Count == 5;
    }
    public int GetIndex()
    {
        return pilha.Count;
    }
    public void MostrarPilha()
    {
        if (pilha.Count == 0)
        {
            Debug.Log("A pilha está vazia.");
        }
        else
        {
            Debug.Log("Pilha:");
            foreach (char valor in pilha)
            {
                Debug.Log(valor);
            }
        }
    }
}
