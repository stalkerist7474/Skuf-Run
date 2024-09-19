
public struct TutorialStepEvent : IEvent
{
	public readonly int StepType;
	public bool BeginStep;

    public TutorialStepEvent(int stepType, bool beginStep)
    {
        StepType = stepType;
        BeginStep = beginStep;
    }
}