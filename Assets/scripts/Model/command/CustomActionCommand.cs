using UnityEngine.Events;

namespace command
{
    public class CustomActionCommand:Command
    {
        private UnityAction action;

        public CustomActionCommand(UnityAction act)
        {
            this.action = act;
        }
        public override void StartCommandExecution()
        {
            this.action.Invoke();
            Command.CommandExecutionComplete();
        }
    }
}