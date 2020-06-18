namespace UnitTestProject1
{
    internal class Student
    {
        public int Age
        {
            get
            {
                return 0;
            }
            internal set
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}