using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private ImageControl _imageControl;
    private TextControl _textControl;
    private ScreenControl _screenControl;
    private AvoidSameWord _avoidSameWord;
    private LetterBlock _letterBlock;
    public string currentWord;
    public int currentIndex, level, errors;

    void Start()
    {
        _imageControl = GetComponent<ImageControl>();
        _textControl = GetComponent<TextControl>();
        _screenControl = GetComponent<ScreenControl>();
        _avoidSameWord = GetComponent<AvoidSameWord>();
        _letterBlock = GetComponent<LetterBlock>();
        ResetLevel();
    }
    void Update()
    {
        
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
            UpdateTexts();
        }
    }
    public bool AddLevel(){
        if(level <= 5){
            level++;
            return true;
        }
        else{
            _screenControl.SetActiveScreen("end"); // chamar tela final
            // resetar
            return false;
        }
    }
    public void ResetLevel(){
        level = 0;
    }
    public void UpdateTexts(){
        _textControl.SetAllText(
            _imageControl._sprites[currentIndex].grupo, 
            level.ToString(), 
            errors.ToString(), 
            _imageControl._sprites[currentIndex].dica);
    }

    public void SortWord() //escolher a palavra
    {
        currentIndex = UnityEngine.Random.Range(0, _imageControl.CountList());
        currentWord = _imageControl.SelectWord(currentIndex);
    }
}
