using System.Collections.Generic;
using System.IO;
using Clothing;
using Commands;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class CodeEditorController : MonoBehaviour
{
    private InputField _inputField;
    private List<CommandInfo> _commandInfoList;
    private ClothingManager _clothingManager;

    private void Start()
    {
        using (StreamReader r = new StreamReader(@"Assets\Scripts\Commands\Commands.json"))
        {
            string json = r.ReadToEnd();
            _clothingManager = gameObject.GetComponent<ClothingManager>();
            _commandInfoList = JsonConvert.DeserializeObject<List<CommandInfo>>(json);
        }

        _inputField = gameObject.GetComponent<InputField>();
    }

    public void OnButtonClick()
    {    
        var codeInputByLine = _inputField.text.Split('\n');

        foreach (var codeLine in codeInputByLine)
        {
            foreach (var commandInfo in _commandInfoList)
            {    
                var executor = commandInfo.GetExecutor() + "(";
                
                if (!codeLine.Contains(executor)) continue;
                
                var parameter = codeLine.Replace(executor, "");
                parameter = parameter.Replace(")", "");
                if (commandInfo.GetOptionsType() != "Color")
                {
                    var foundOption = commandInfo.GetOptions().Find(option => 
                    option == parameter);

                    switch (commandInfo.GetExecutor().Split('.')[0])
                    {
                        //todo: add functions for each case    
                        case "Neck":
                            break;
                        
                        case "Sleeve":
                            _clothingManager.ChangeSleeve(foundOption);
                            break;
                        
                        case "TrouserLegs":
                            break;
                        
                        case "Skirt":
                            break;
                        
                        case "Pattern":
                            break;
                    }
                }
                else
                {
                    if (commandInfo.GetOptionsMap().ContainsKey(parameter))
                    {
                        //todo: execute color changer with key value
                    }
                }
            }
        }
    }
}