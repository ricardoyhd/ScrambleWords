using UnityEngine;

public class tools : MonoBehaviour
{
    // Função TrimText que corta o texto entre as posições iniciais e finais
    public string TrimText(string textObject, int startPosition, int endPosition)
    {
        // Verifica se o objeto possui o componente Text
        string objectName = textObject;
        if (objectName == null)
        {
            Debug.LogError("O GameObject não possui um componente Nome.");
            return null;
        }

        // Verifica se as posições estão dentro dos limites do texto
        if (startPosition < 0 || endPosition >objectName.Length || startPosition > endPosition)
        {
            Debug.LogError("Posições inválidas para o corte do texto.");
            return null;
        }

        // Retorna o texto cortado entre as posições especificadas
        return objectName.Substring(startPosition, endPosition - startPosition);
    }

     public string getObjectName(string name)
    {
        return name;
    }
    public string firstLetter(string name)
    {
        //string name = getObjectName();
        string letterName = TrimText(name, 4, 5);
        //Debug.Log(letterName);
        return letterName;
    }
    public string wordFirstLetter(string name)
    {
        string letterName = TrimText(name, 0, 1);
        return letterName;
    }

    public string RemoveFirstLetter(string name)
    {   
        string rest = name.Substring(1).ToUpper();
        return rest;
    }

    public void SetImageName(string name)
    {   
        Debug.Log("Palavra: " + getObjectName(name));
        Debug.Log("Primeira letra da palavra: " + firstLetter(name));
    }
}