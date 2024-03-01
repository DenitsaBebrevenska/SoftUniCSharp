namespace CommandPattern.Commands;
class DivideCommand : Command
{
    public DivideCommand(decimal value) : base(value)
    {
        Operator = '/';
    }

    public override decimal Execute(decimal calculatorValue)
    => calculatorValue / Value;

    public override decimal UnExecute(decimal calculatorValue)
    => calculatorValue * Value;
}

