namespace PeopleVille.Persons
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }
        // TODO: Tilføj inventory når Equipment er oprettet
        public List<object> Inventory { get; set; }
        public object Location { get; set; }
        public int Money { get; set; }
        public int Age { get; set; }


        public void Walk(object location)
        {
            this.Location = location;
        }
    }
}