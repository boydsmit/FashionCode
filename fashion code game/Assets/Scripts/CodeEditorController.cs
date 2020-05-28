using System.Collections.Generic;
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
        var commands = Resources.Load<TextAsset>("Commands");

        _commandInfoList = JsonConvert.DeserializeObject<List<CommandInfo>>(commands.text);

        _clothingManager = GameObject.FindWithTag("generator").GetComponent<ClothingManager>();
        _spriteHandler = GameObject.FindWithTag("generator").GetComponent<SpriteHandler>();
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
                
                if (!codeLine.ToLower().Contains(executor)) continue;
                
                var parameter = codeLine.Replace(executor, "");
                parameter = parameter.Replace(")", "");
                if (commandInfo.GetOptionsType() != "Color")
                {
                    var foundOption = commandInfo.GetOptions().Find(option => 
                    option == parameter);

                    switch (commandInfo.GetExecutor().Split('.')[0].ToLower())
                    {
                        case "neck":
                            break;
                        
                        case "sleeve":
                            _clothingManager.PlayParticleOnClick();
                            _clothingManager.ChangeSleeve(foundOption);
                            break;
                        
                        case "pants":
                            _clothingManager.PlayParticleOnClick();
                            _clothingManager.ChangePants(foundOption);
                            break;
                        
                        case "skirt":
                            _clothingManager.PlayParticleOnClick();
                            _clothingManager.ChangeSkirt(foundOption);
                            break;
                        
                        case "pattern":
                            _clothingManager.PlayParticleOnClick();
                            _clothingManager.ChangePattern(foundOption);
                            break;
                    }
                }
                else
                {
                    if (!commandInfo.GetOptionsMap().ContainsKey(parameter)) continue;
                    
                    commandInfo.GetOptionsMap().TryGetValue(parameter, out var value);
                    _clothingManager.PlayParticleOnClick();
                    if (executor.Contains("1"))
                    {
                        _spriteHandler.ChangeSpriteColor(value, "Clothing");
                    } 
                    _spriteHandler.ChangeSpriteColor(value, "Pattern");
                }
            }
        }
    }
}