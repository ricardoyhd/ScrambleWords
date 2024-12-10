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
        public GameObject Block;
    }
    [SerializeField] private List<BlockLetter> _letterBlock = new List<BlockLetter>();
    [SerializeField] private List<Vector2> _letterBlockOriginalPositions = new List<Vector2>();
    private LogicScript _logicScript;
    private Pilha _pilha;
    private BlocksControl _blocks;
    void Start()
    {
        _logicScript = GetComponent<LogicScript>();
        _pilha = GetComponent<Pilha>();
        _blocks = GetComponent<BlocksControl>();
        for(int i = 0; i < 5; i++)
        {
            _letterBlockOriginalPositions.Add(_letterBlock[i].Block.transform.position);
        }
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

    public void CheckLetterBlock(int index) // chamar quando é clicado no botão específico 
    {
        // adicionar animação para ir até o bloco
        if(_pilha.Empilhar(_letterBlock[index].letter, _logicScript.currentWord)){
            _letterBlock[index].button.enabled = false; // não é possível clicar nele denovo
            _blocks.GoToTarget(_letterBlock[index].Block, _pilha.GetIndex() - 1);
        }
        else{
            // animação de voltar
            _logicScript.AddError();
        }
    }

    public void ResetLetterBlocks()
    {
        for(int i = 0; i < 5; i++)
        {
            _blocks.ReturnPositions(_letterBlock[i].Block, _letterBlockOriginalPositions[i]);
        }
    }
    public void EnableAllButtons(bool state)
    {
        for(int i = 0; i < 5; i++)
        {
            _letterBlock[i].button.enabled = state;
        }
    }
    public bool CheckWord()
    {
        if(_pilha.Cheia())
        {
            _pilha.LimparPilha();
            return true;
        }
        return false;
    }
    public void LimparPilha()
    {
        _pilha.LimparPilha();
    }
}
