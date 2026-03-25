# PeopleVille projekt

## TODO
### Benjamin
- [ ] Implementer dynamisk import af "eksterne" dll'er
- [ ] Find ud af hvordan tid skal fungere
### Mikkel
- [ ] Lav worldbuilder

**Husk at opdatere mermaid løbende**

```mermaid
classDiagram
    class IEquipment {
        <<interface>>
        +void Equip()
        +void Unequip()
        +void Use()
    }

    class ICitizenBuilder {
        <<interface>>
        +ICitizenBuilder CreateAdult()
        +ICitizenBuilder CreateChild()
        +ICitizenBuilder WithGun()
        +ICitizenBuilder WithFood()
        +Person BuildCitizens()
    }

    class ITownBuilder {
        <<interface>>
        +ITownBuilder AddGunStore()
        +ITownBuilder AddEggStore()
        +ITownBuilder AddBank()
        +List~Location~ BuildTown();
    }

    class Gun {
        +string Name
        +int Damage
        +void Use()
    }
    class Food {
        +string Name
        +int HealthPoints
        +void Use()
    }

    class Person {
        <<abstract>>
        +string Name
        +int Health
        +List~IEquipment~ Inventory
    }

    class AdultCitizen{

    }

    class ChildCitizen{

    }

    class Location {
        <<abstract>>
        +string Name
    }
    class Store {
        +Dictionary~object, int~ Inventory
    }

    class Bank{

    }

    class GunStore{

    }

    class EggStore{

    }

    class CitizenBuilder{
        +ICitizenBuilder CreateAdult()
        +ICitizenBuilder CreateChild()
        +ICitizenBuilder WithGun()
        +ICitizenBuilder WithFood()
        +Person BuildCitizens()
    }

    class TownBuilder {
        +ITownBuilder AddGunStore()
        +ITownBuilder AddEggStore()
        +ITownBuilder AddBank()
        +List~Location~ BuildTown()
    }

    class GameManager {
        -List~Store~ Stores
        +Task StartClock()
    }

    class RNG {
        +int ThrowDice()
        +int Range()
    }

    class Die {
        +int Sides
    }
    RNG --|> Die

    Gun ..|> IEquipment
    Food ..|> IEquipment
    
    AdultCitizen --|> Person
    ChildCitizen --|> Person
    Person o-- IEquipment

    Bank --|> Location
    Store --|> Location
    GunStore --|> Store
    EggStore --|> Store

    CitizenBuilder ..|> ICitizenBuilder
    TownBuilder ..|> ITownBuilder
    CitizenBuilder --> Person
    TownBuilder --> Location
    GameManager --> Store

```