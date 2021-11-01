using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class IdProvider : IIdProvider
    {
        private static int id;

        public int Id 
        {
            get
            {
                return ++id;
            }
        }
    }
}
