using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class CodeEditorController : MonoBehaviour
{
    private InputField _inputField;
    private List<CommandInfo> _commandInfoList;

    private void Start()
    {
        using (StreamReader r = new StreamReader(@"Assets\Scripts\Commands\Commands.json"))
        {
            string json = r.ReadToEnd();
            print(json);
            _commandInfoList = JsonConvert.DeserializeObject<List<CommandInfo>>(json);
        }
        _inputField = gameObject.GetComponent<InputField>();
    }

    public void OnButtonClick()
    {
        string[] writtenCode = _inputField.text.Split('\n');
        string[] codeSpaghettiMode = {"Neck.Sew"};
        string[] optionsSpaghettiMode = {"Red", "Green", "Blue"};

        // XmlReader xmlReader = new XmlReader();
        //
        // xmlReader.CreateCommandInfo(@"Assets\Scripts\Commands\Commands.xml", "command");
        
        for (int i = 0; i < writtenCode.Length; i++)
        {
            if (writtenCode[i].Contains(codeSpaghettiMode[i] + '('))
            {
                string parameter = writtenCode[i].Replace(codeSpaghettiMode[i] + "(", "");
                foreach (var option in optionsSpaghettiMode)
                {
                    if (option == parameter.Replace(")", ""))
                    {
                        print("The parameter was: " + option);
                    }    
                }
            }
        }
    }
}