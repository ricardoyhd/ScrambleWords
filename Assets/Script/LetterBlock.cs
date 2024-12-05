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
        public TextMeshProUGUI letterText;
        public char letter;
    }
    [SerializeField] private List<BlockLetter> _letterBlock = new List<BlockLetter>();
    private LogicScript _logicScript;
    private Pilha _pilha;
    void Start()
    {
        _logicScript = GetComponent<LogicScript>();
        _pilha = GetComponent<Pilha>();
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
            _letterBlock[i].letter = scrambledLetters[i]; // variável char
            _letterBlock[i].letterText.text = scrambledLetters[i].ToString(); // letra que aparece no jogo
        }
    }
    public char[] GetScrambledWord(char[] letters) // embaralhar palavra usando Knuth Shuffle
    {
        for (int i = letters.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            char temp = letters[i];
            letters[i] = letters[j];
            letters[j] = temp;
        }
        return letters;
    }

    public void CheckLetterBlock(int index){ // chamar quando é clicado no botão específico 
        // adicionar animação para ir até o bloco
        bool DeuCerto = false;
        _pilha.Empilhar(_letterBlock[index].letter, ref DeuCerto);
        Debug.Log(DeuCerto);
        if(DeuCerto){
            // bloco fica no lugar
            // pilha vai pro próximo
        }
        else{
            // animação de voltar
            // soma 1 para o erro _logicScript.AddError
            // tenta denovo
        }
    }
}
