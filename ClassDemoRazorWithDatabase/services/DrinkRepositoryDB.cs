using ClassDemoRazorWithDatabase.model;

namespace ClassDemoRazorWithDatabase.services
{
    public class DrinkRepositoryDB : IDrinkRepo
    {

        private EFDrinkContext _db;

        public DrinkRepositoryDB()
        {
            _db = new EFDrinkContext();
        }

        public Drink Add(Drink newDrink)
        {
            newDrink.Id = 0;
            _db.Drinks.Add(newDrink);
            _db.SaveChanges();

            return newDrink;
        }

        public Drink Delete(int id)
        {
            Drink d = GetById(id);
            _db.Drinks.Remove(d);
            _db.SaveChanges();

            return d;
        }

        public List<Drink> GetAll()
        {
            return new List<Drink>(_db.Drinks);
        }

        public List<Drink> GetAllDrinksSortedByNameReversed()
        {
            return new List<Drink>(_db.Drinks.OrderByDescending(d => d.Name));
        }

        public Drink GetById(int id)
        {
            Drink? drink = _db.Drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null)
            {
                throw new KeyNotFoundException();
            }
            return drink;
        }

        public Drink Update(int id, Drink updatedDrink)
        {
            Drink drink = GetById(id);

            drink.Name = updatedDrink.Name;
            drink.Alk = updatedDrink.Alk;

            _db.SaveChanges();
            return drink;
        }
    }
}
