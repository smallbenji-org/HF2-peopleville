# PeopleVille projekt

## TODO
### Benjamin
- [ ] Implementer dynamisk import af "eksterne" dll'er
- [ ] Find ud af hvordan tid skal fungere
### Mikkel
- [ ] En person skal kunne have en gun og food
- [ ] Lav worldbuilder

**Huskt at opdatere mermaid løbende**

```mermaid
classDiagram
    class IEquipment{
        <<interface>>
        +void Equip()
        +void Unequip()
        +void Use()
    }
    Food ..|> IEquipment
    Gun ..|> IEquipment

    class Person{
        <<abstract>>
        +string Name
        +int Health
        +List~Equipment~ Inventory
        +Location Location
        +int Money
        +int Age
        +void Walk()
    }
    AdultCitizen --|> Person
    ChildCitizen --|> Person
    IEquipment ..|> Person

    class AdultCitizen{
    }
    class ChildCitizen{
    }

    class Location{
        <<abstract>>
        +string Name
    }
    Bank --|> Location
    Store --|> Location
    Person ..|> Location

    class Logger{
        <<singleton>>
        +void Log()
    }

    class Food{
        +string Name
        +int HealthPoints
        +Use()
    }

    class Gun{
        +string Name
        +int Damage
        +Use()
    }

    class Store{
        +Dictionary~IEquipment int~ Inventory
    }
    GunStore --|> Store
    EggStore --|> Store
    IEquipment --|> Store

    class SimulationManager{
        +void StartSim()
        +List~Equipment~ Equipment
        +List~Location~ Locations
    }
    IEquipment ..|> SimulationManager
    Person ..|> SimulationManager
    Location ..|> SimulationManager

```