namespace CommandPattern.Commands;

abstract class Command
{
    protected Command(decimal value)
    {
        Value = value;
    }

    public char Operator { get; set; }

    public decimal Value { get; set; }

    public abstract decimal Execute(decimal calculatorValue);

    public abstract decimal UnExecute(decimal calculatorValue);

}

