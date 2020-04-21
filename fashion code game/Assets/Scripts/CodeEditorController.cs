using UnityEngine;
using UnityEngine.UI;

public class CodeEditorController : MonoBehaviour
{
    private InputField _inputField;

    private void Start()
    {
        _inputField = gameObject.GetComponent<InputField>();
    }

    private void OnButtonClick()
    {
        string[] writtenCode = _inputField.text.Split('\n');
        string[] test = {"Hi", "Hello"};
    for (int i = 0; i < writtenCode.Length; i++)
        {
            if (writtenCode[i] == test[i])
            {
                print("Correct!");
            }
        }
    }
 
}
