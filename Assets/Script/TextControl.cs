using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI tipText;
    
    public void SetAllText(string category, string level, string error, string tip){
        SetCategory(category);
        SetLevel(level);
        SetError(error);
        SetTip(tip);
    }
    public void SetCategory(string category){
        categoryText.text = "Categoria: \n" + category;
    }
    public void SetLevel(string level){
        levelText.text = "Level: " + level;
    }
    public void SetError(string error){
        errorText.text = "Erros: " + error;
    }
    public void SetTip(string tip){
        tipText.text = "Dica: " + tip;
    }
}
