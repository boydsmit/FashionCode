using System.Collections;
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
    private SpriteHandler _spriteHandler;
    
    private void Start()
    {
        using (var r = new StreamReader(@"Assets\Scripts\Commands\Commands.json"))
        {
            var json = r.ReadToEnd();
            _clothingManager = GameObject.FindWithTag("generator").GetComponent<ClothingManager>();
            _spriteHandler = GameObject.FindWithTag("generator").GetComponent<SpriteHandler>();
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
                        case "Neck":
                            break;
                        
                        case "Sleeve":
                            _clothingManager.PlayParticleOnClick();
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
                    if (!commandInfo.GetOptionsMap().ContainsKey(parameter)) continue;
                    
                    commandInfo.GetOptionsMap().TryGetValue(parameter, out var value);
                    _clothingManager.PlayParticleOnClick();
                    _spriteHandler.ChangeSpiteColor(value);
                }
            }
        }
    }
}