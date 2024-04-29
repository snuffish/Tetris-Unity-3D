using Unity.VisualScripting;

namespace State
{
    [UnitTitle("SnuffTool - MyEventUnit")]
    [UnitCategory("SnuffTool\\MyEventUnit")]
    public class MyEventUnit : EventUnit<int>
    {
        private EventUnit<int> _eventUnitImplementation;
        protected override bool register => true;
    }
}