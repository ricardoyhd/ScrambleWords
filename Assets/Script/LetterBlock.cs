using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterBlock : MonoBehaviour
{
    [System.Serializable] // estrutura aninhada
    public class BlockLetter
    {
        public Button button;
        public TextMeshProUGUI letter;
    }
    [SerializeField] private List<BlockLetter> _letterBlock = new List<BlockLetter>();
    private LogicScript _logicScript;
    void Start()
    {
        _logicScript = GetComponent<LogicScript>();
    }
    void Update()
    {
    }
    public void GetLetterForBlock(string currentWord)
    {
        char[] scrambledLetters = GetScrambledWord(currentWord.ToCharArray());

        Debug.Log("Current Word: " + currentWord);
        Debug.Log("Scrambled Word: " + scrambledLetters[0] + scrambledLetters[1] + scrambledLetters[2] + scrambledLetters[3] + scrambledLetters[4]);

        for(int i = 0; i < 5; i++)
        {
            _letterBlock[i].letter.text = scrambledLetters[i].ToString();
        }
    }
    public char[] GetScrambledWord(char[] letters) //escolher a palavra
    {
        System.Random rand = new System.Random();

        for (int i = letters.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            char temp = letters[i];
            letters[i] = letters[j];
            letters[j] = temp;
        }
        return letters;
    }
}
