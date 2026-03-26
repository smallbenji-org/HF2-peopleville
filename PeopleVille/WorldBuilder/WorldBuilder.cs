using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;
using PeopleVille;
using System.Reflection;
namespace PeopleVille.WorldBuilder
{
    public class WorldBuilder :
        IWorldBuilder,
        IGameManagerBuilder,
        IEquipmentBuilder,
        ILocationBuilder,
        IPersonBuilder
    {
        private World world;

        public IGameManagerBuilder AddGameManager()
        {
            world = new World();
            return this;
        }

        IEquipmentBuilder IGameManagerBuilder.AddEquipment()
        {
            return this;
        }

        ILocationBuilder IEquipmentBuilder.AddLocations()
        {
            return this;
        }

        IPersonBuilder ILocationBuilder.AddPersons()
        {
            return this;
        }

        IWorldBuilder IPersonBuilder.EndWorldBuilding()
        {
            return this;
        }

        IEquipmentBuilder IEquipmentBuilder.FromRange(IEnumerable<IEquipment> equipment)
        {
            world.Equipment.AddRange(equipment);
            return this;
        }

        ILocationBuilder ILocationBuilder.FromRange(IEnumerable<Location> locations)
        {
            world.Locations.AddRange(locations);
            return this;
        }

        IPersonBuilder IPersonBuilder.FromRange(IEnumerable<Person> people)
        {
            world.People.AddRange(people);
            return this;
        }

        World IWorldBuilder.Build()
        {
            foreach (var person in world.People)
            {
                person.Manager = world.manager;
            }

            return world;
        }

        ILocationBuilder ILocationBuilder.FromFile(string pathToFile)
        {
            world.Locations.AddRange(LoadTypesFromAssembly<Location>(pathToFile));
            return this;
        }

        IPersonBuilder IPersonBuilder.FromFile(string pathToFile)
        {
            world.People.AddRange(LoadTypesFromAssembly<Person>(pathToFile));
            return this;
        }

        IEquipmentBuilder IEquipmentBuilder.FromFile(string pathToFile)
        {
            world.Equipment.AddRange(LoadTypesFromAssembly<IEquipment>(pathToFile));
            return this;
        }

        IEquipmentBuilder IEquipmentBuilder.FromFolder(string pathToFolder)
        {
            world.Equipment.AddRange(LoadTypesFromAssemblyFolder<IEquipment>(pathToFolder));
            return this;
        }

        ILocationBuilder ILocationBuilder.FromFolder(string pathToFolder)
        {
            world.Locations.AddRange(LoadTypesFromAssemblyFolder<Location>(pathToFolder));
            return this;
        }

        IPersonBuilder IPersonBuilder.FromFolder(string pathToFolder)
        {
            world.People.AddRange(LoadTypesFromAssemblyFolder<Person>(pathToFolder));
            return this;
        }

        private List<T> LoadTypesFromAssemblyFolder<T>(string pathToAssemblyFolder) where T : class
        {
            var instances = new List<T>();
            string[] dlls = Directory.GetFiles(pathToAssemblyFolder, "*.dll");

            foreach (var dll in dlls)
            {
                instances.AddRange(LoadTypesFromAssembly<T>(dll));
            }

            return instances;
        }

        private List<T> LoadTypesFromAssembly<T>(string pathToAssembly) where T : class
        {
            var instances = new List<T>();

            Assembly assembly = Assembly.LoadFrom(pathToAssembly);


            var types = assembly.GetTypes().Where(t =>
                typeof(T).IsAssignableFrom(t) &&
                !t.IsInterface &&
                !t.IsAbstract
            );

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type) as T;
                if (instance != null) instances.Add(instance);
            }

            return instances;
        }
    }
}
