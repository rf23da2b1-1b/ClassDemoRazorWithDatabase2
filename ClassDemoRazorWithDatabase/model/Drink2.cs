namespace ClassDemoRazorWithDatabase.model
{
    public class Drink2 : IComparable<Drink2>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool Alc { get; set; }

        public Drink2(int id, string name, bool alc)
        {
            Id = id;
            Name = name;
            Alc = alc;
        }

        public Drink2() : this(-1, "dummy", false)
        {
        }




        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Alc)}={Alc.ToString()}}}";
        }

        public int CompareTo(Drink2? other)
        {
            if (other is null)
            {
                return -1;
            }

            return Name.CompareTo(other.Name);
        }

        public class DrinkSortByIdReverse : IComparer<Drink2>
        {
            public int Compare(Drink2? x, Drink2? y)
            {
                if (x is null)
                {
                    return 1;
                }

                if (y is null)
                {
                    return -1;
                }

                return y.Id.CompareTo(x.Id);
            }

        }
    }
}
