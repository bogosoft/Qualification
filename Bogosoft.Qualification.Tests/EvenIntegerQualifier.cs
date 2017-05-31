namespace Bogosoft.Qualification.Tests
{
    class EvenIntegerQualifier : IQualify<int>
    {
        public bool Qualify(int integer)
        {
            return integer % 2 == 0;
        }
    }
}