namespace RPM_Lab8.Mediator;

public abstract class Colleague
{
    public IMediator Mediator { get; protected set; }

    public void SetMediator(IMediator mediator) 
        => Mediator = mediator;
}