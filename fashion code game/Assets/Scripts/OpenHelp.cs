using System.Collections.Generic;
using Commands;
using UnityEngine;
using UnityEngine.UI;

public class OpenHelp : MonoBehaviour
{
    private List<CommandInfo> _commandInfos = new List<CommandInfo>();

    private void Start()
    {
        var commandInfo = new CommandInfo();
        _commandInfos = commandInfo.GetAllCommandInfos("Commands");
        ShowHelp();
    }

    public void ShowHelp()
    {
        var helpText = GameObject.FindWithTag("HelpText").GetComponent<Text>();

        helpText.text = "";
        foreach (var commandInfo in _commandInfos)
        {
            helpText.text = helpText.text + "<b>" + commandInfo.GetExecutor() + "(</b><i>parameter</i><b>)</b>";
            if (commandInfo.GetOptions() != null)
            {
                foreach (var option in commandInfo.GetOptions())
                {
                    helpText.text = helpText.text + "\n" + option;
                }
            }
            else
            {
                foreach (var option in commandInfo.GetOptionsMap())
                {
                    helpText.text = helpText.text + "\n" + option.Key;
                }
            }

            helpText.text = helpText.text + "\n\n";
        }
    }
}
