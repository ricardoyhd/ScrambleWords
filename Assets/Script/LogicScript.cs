using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private ImageControl _imageControl;
    private TextControl _textControl;
    private AvoidSameWord _avoidSameWord;
    private LetterBlock _letterBlock;
    public string currentWord;
    public int currentIndex;
    public int errors;

    void Start()
    {
        _imageControl = GetComponent<ImageControl>();
        _textControl = GetComponent<TextControl>();
        _avoidSameWord = GetComponent<AvoidSameWord>();
        _letterBlock = GetComponent<LetterBlock>();
        NextLevel();
    }
    void Update()
    {
        
    }

    public void NextLevel()
    {
        SortWord();
        while(!_avoidSameWord.AddWord(currentWord)){
            SortWord();
        }
        _letterBlock.GetLetterForBlock(currentWord);
        _imageControl.SetImage(currentWord);
    }

    public void SortWord() //escolher a palavra
    {
        currentIndex = UnityEngine.Random.Range(0, _imageControl.CountList());
        currentWord = _imageControl.SelectWord(currentIndex);
    }
}
