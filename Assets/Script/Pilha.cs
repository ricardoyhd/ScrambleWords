using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilha : MonoBehaviour
{
    [SerializeField] private Stack<char> pilha = new Stack<char>();
    public string ChosenWord;

    public void Empilhar(char valor, ref bool DeuCerto)
    {
        if (!Cheia())
        {   
            if(valor == ChosenWord[pilha.Count])
            {
                // animação vai até o bloco
                pilha.Push(valor);
                DeuCerto = true;
            } 
            else
            {
                DeuCerto = false;
            }
        }
        
    }

    public void Remover()
    {
        if (!Vazia())
        {
            pilha.Pop();
        }
        else
        {
            Debug.Log("Pilha vazia");
        }
    }

    public bool Vazia()
    {
        return pilha.Count == 0;
    }
    public bool Cheia()
    {
        return pilha.Count == 5;
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
