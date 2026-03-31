using RPM_Lab8.State;

namespace RPM_Lab8.Mediator;

public interface IMediator
{
    void Notify(Colleague sender, string ev, Document document = null);
}