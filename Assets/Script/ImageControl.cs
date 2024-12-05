using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ImageControl : MonoBehaviour
{
    [System.Serializable] // estrutura aninhada
    public class SpriteData
    {
        public Sprite sprite; // Componente Sprite para cada imagem
        public string nome;
        public string grupo;
        public string dica;
    }

    [SerializeField] private List<SpriteData> _sprites = new List<SpriteData>();
    [SerializeField] private Image _block;
    [SerializeField] private Sprite _currentSprite;

    public void SetImage(string word)
    {
        SetCurrentSprite(word);
        _block.sprite = _currentSprite;
    }

    // Procura o sprite
    private void SetCurrentSprite(string word)
    {
        for (int i = 0; i < _sprites.Count; i++)
        {
            if (_sprites[i].nome == word)
            {
                _currentSprite = _sprites[i].sprite;
            }
        }
    }

    public string SelectWord(int index)
    {
        return _sprites[index].nome;
    }
    public string GetGrupo(int index)
    {
        return _sprites[index].grupo;
    }
    public string GetDica(int index)
    {
        return _sprites[index].dica;
    }
    public int CountList()
    {
        return _sprites.Count;
    }
}
