using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    TMP_Text _textDialogue;

    [SerializeField]
    string [] arrayDialog;

    int i = 0;

    public void NextDialogue()
    {
        _textDialogue.text = arrayDialog[i].ToString();
        i++;
    }

}
