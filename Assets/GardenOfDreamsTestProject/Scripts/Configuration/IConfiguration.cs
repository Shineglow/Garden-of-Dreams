namespace GardenOfDreamsTestProject.Scripts.Configuration
{
    public interface IConfiguration<T1, T2>
    {
        public T2 GetData(T1 configurationOfType);
    }
}