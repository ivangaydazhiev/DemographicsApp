namespace Demographics.Domain.Entities
{
    public class StatePopulation
    {
        public int Id { get; set; }

        public string StateName { get; set; } = null!;

        public long Population { get; set; }

        public DateTime LastUpdated { get; set; }


    }
}
