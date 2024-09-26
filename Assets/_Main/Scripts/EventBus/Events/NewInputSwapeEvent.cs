
public struct NewInputSwapeEvent : IEvent
{

    public ActionInput ActionInput;

    public NewInputSwapeEvent(ActionInput actionInput)
    {
        ActionInput = actionInput;

    }
}
