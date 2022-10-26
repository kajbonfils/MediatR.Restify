namespace MinimalApiTest.Repo
{

    public interface ICarModelRepository
    {
        int Add(string name);
        CarModelEntity? Get(int id);
        List<CarModelEntity> GetAll();
    }
    public class CarModelRepository : ICarModelRepository
    {
        private static List<CarModelEntity> carmodels;

        public CarModelRepository()
        {
            if (carmodels == null)
                carmodels = new List<CarModelEntity>();
        }

        public int Add(string name)
        {
            var id = !carmodels.Any()?0:carmodels.Max(p => p.Id)+1;
            carmodels.Add(new CarModelEntity(id, name));
            return id;
        }

        public CarModelEntity? Get(int id)
        {
            return carmodels.FirstOrDefault(p => p.Id== id);
        }

        public List<CarModelEntity> GetAll()
        {
            return carmodels;
        }
    }

    public record CarModelEntity(int Id, string Name); 
}
