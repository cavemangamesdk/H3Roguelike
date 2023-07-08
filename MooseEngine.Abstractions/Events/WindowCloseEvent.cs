namespace MooseEngine.Events;

public class WindowCloseEvent : EventBase
{
    public override EventType Type => EventType.WindowClose;
    public override EventCategory Category => EventCategory.EventCategoryApplication;
}
