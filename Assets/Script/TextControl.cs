using TMPro;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI tipText;
    
    public void SetAllText(string category, string level, string error, string tip){
        SetCategory(category);
        SetStorage(level);
        SetError(error);
        SetTip(tip);
    }
    public void SetCategory(string category){
        categoryText.text = category;
    }
    public void SetStorage(string level){
        levelText.text = level;
    }
    public void SetError(string error){
        errorText.text = error;
    }
    public void SetTip(string tip){
        tipText.text = tip;
    }
}
