using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private ImageControl _imageControl;
    private TextControl _textControl;
    private ScreenControl _screenControl;
    private AvoidSameWord _avoidSameWord;
    private LetterBlock _letterBlock;
    public string currentWord;
    public int currentIndex, level, error, incorrect;

    void Start()
    {
        _imageControl = GetComponent<ImageControl>();
        _textControl = GetComponent<TextControl>();
        _screenControl = GetComponent<ScreenControl>();
        _avoidSameWord = GetComponent<AvoidSameWord>();
        _letterBlock = GetComponent<LetterBlock>();
        ResetLevels();
    }
    void Update()
    {
        if(_letterBlock.CheckWord())
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        if(AddLevel())
        {
            SortWord();
            while(!_avoidSameWord.AddWord(currentWord)){
                SortWord();
            }
            _letterBlock.GetLetterForBlock(currentWord);
            _imageControl.SetImage(currentWord);
            _textControl.TipCategoryText(false);
            _letterBlock.EnableAllButtons(true);
            error = 0;
            UpdateTexts();
        }
    }
    public bool AddLevel()
    {
        _letterBlock.ResetLetterBlocks();
        if(level < 5){
            level++;
            return true;
        }
        else{
            _screenControl.SetActiveScreen("End"); // chamar tela final
            _textControl.SetEndText((5 - incorrect).ToString());
            ResetLevels();
            return false;
        }
    }
    public void AddError()
    {
        error++;
        _textControl.SetError(error.ToString());
        if(error == 1)
        {
            _textControl.TipCategoryText(true);
        }
        if(error == 3)
        {
            incorrect++;
            error = 0;
            _letterBlock.LimparPilha();
            NextLevel();
        }
    }
    public void ResetLevels()
    {
        level = 0;
        incorrect = 0;
    }
    public void UpdateTexts()
    {
        _textControl.SetAllText(
            _imageControl._sprites[currentIndex].grupo, 
            level.ToString(), 
            error.ToString(), 
            _imageControl._sprites[currentIndex].dica);
    }
    public void SortWord() //escolher a palavra
    {
        currentIndex = Random.Range(0, _imageControl.CountList());
        currentWord = _imageControl.SelectWord(currentIndex);
    }
}
