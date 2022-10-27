namespace  Hr.Interfaces
{
    public interface IunitOfWork<t> where t : class
    {
        IGenericRepository<t> Entity { get; }

        void save();
    }
}
