namespace MooseEngine.Events;

public class EventDispatcher
{
    private readonly EventBase _event;

    public EventDispatcher(EventBase @event)
    {
        _event = @event;
    }

    public bool Dispatch<TEvent>(Func<TEvent, bool> func)
        where TEvent : EventBase
    {
        var e = _event as TEvent;
        if (_event.Type == e?.Type)
        {
            _event.Handled |= func((TEvent)_event);
            return true;
        }

        return false;
    }
}