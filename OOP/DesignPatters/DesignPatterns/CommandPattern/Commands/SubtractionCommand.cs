namespace CommandPattern.Commands
{
    class SubtractionCommand : Command
    {
        public SubtractionCommand(decimal value) : base(value)
        {
            Operator = '-';
        }

        public override decimal Execute(decimal calculatorValue)
        => calculatorValue - Value;

        public override decimal UnExecute(decimal calculatorValue)
        => calculatorValue + Value;
    }
}
