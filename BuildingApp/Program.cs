using System;
using System.Collections.Generic;

namespace BuildingManagement
{
    class Program
    {
        private static List<Building> buildings = new List<Building>();

        static void Main(string[] args)
        {
            Console.WriteLine("Система управління будівлями");
            InitializeSampleData();

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewBuilding();
                        break;
                    case "2":
                        ShowAllBuildings();
                        break;
                    case "3":
                        ModifyBuilding();
                        break;
                    case "4":
                        CompareBuildings();
                        break;
                    case "5":
                        DemonstrateVirtualMethod();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("До побачення!");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
            Console.WriteLine("1. Створити нову будівлю");
            Console.WriteLine("2. Показати всі будівлі");
            Console.WriteLine("3. Змінити будівлю");
            Console.WriteLine("4. Порівняти будівлі");
            Console.WriteLine("5. Продемонструвати віртуальний метод");
            Console.WriteLine("6. Вийти");
            Console.Write("Введіть ваш вибір (1-6): ");
        }

        static void InitializeSampleData()
        {
            buildings.Add(new ApartmentBuilding("вул. Головна 123", "Цегла", 5, 20));
            buildings.Add(new ApartmentBuilding("просп. Дубовий 456", "Залізобетон", 10, 40));
            buildings.Add(new Warehouse("вул. Промислова 789", "Метал", 2, "Закритий"));
            buildings.Add(new Warehouse("вул. Фабрична 321", "Камінь", 1, "Відкритий"));
            buildings.Add(new Building("бульв. Парковий 555", "Цегла", 3));
        }

        static void CreateNewBuilding()
        {
            Console.WriteLine("\n=== СТВОРИТИ НОВУ БУДІВЛЮ ===");
            Console.WriteLine("1. Звичайна будівля");
            Console.WriteLine("2. Житловий будинок");
            Console.WriteLine("3. Склад");
            Console.Write("Оберіть тип будівлі (1-3): ");

            string typeChoice = Console.ReadLine();
            Console.Write("Введіть адресу: ");
            string address = Console.ReadLine();
            Console.Write("Введіть матеріал стін (Цегла/Камінь/Залізобетон/Метал): ");
            string material = Console.ReadLine();
            Console.Write("Введіть кількість поверхів: ");
            int floors = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    buildings.Add(new Building(address, material, floors));
                    Console.WriteLine("Звичайну будівлю створено успішно!");
                    break;
                case "2":
                    Console.Write("Введіть кількість квартир: ");
                    int apartments = int.Parse(Console.ReadLine());
                    buildings.Add(new ApartmentBuilding(address, material, floors, apartments));
                    Console.WriteLine("Житловий будинок створено успішно!");
                    break;
                case "3":
                    Console.Write("Введіть тип планування (Відкритий/Закритий/Напівзакритий): ");
                    string layout = Console.ReadLine();
                    buildings.Add(new Warehouse(address, material, floors, layout));
                    Console.WriteLine("Склад створено успішно!");
                    break;
                default:
                    Console.WriteLine("Невірний тип будівлі!");
                    break;
            }
        }

        static void ShowAllBuildings()
        {
            Console.WriteLine("\n=== ВСІ БУДІВЛІ ===");
            if (buildings.Count == 0)
            {
                Console.WriteLine("В системі немає будівель.");
                return;
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                Console.WriteLine($"\n--- Будівля #{i + 1} ---");
                buildings[i].ShowInfo();
            }
        }

        static void ModifyBuilding()
        {
            if (buildings.Count == 0)
            {
                Console.WriteLine("Немає будівель для зміни.");
                return;
            }

            Console.WriteLine("\n=== ЗМІНИТИ БУДІВЛЮ ===");
            ShowAllBuildings();
            Console.Write("Введіть номер будівлі для зміни: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= buildings.Count)
            {
                Console.WriteLine("Невірний номер будівлі!");
                return;
            }

            var building = buildings[index];
            Console.WriteLine($"Змінюємо: {building}");

            if (building is ApartmentBuilding apt)
            {
                Console.Write("Введіть нову кількість квартир: ");
                int newApts = int.Parse(Console.ReadLine());
                apt.ChangeApartmentsCount(newApts);
                Console.WriteLine("Кількість квартир оновлено!");
            }
            else if (building is Warehouse wh)
            {
                Console.Write("Введіть новий тип планування (Відкритий/Закритий/Напівзакритий): ");
                string newLayout = Console.ReadLine();
                wh.ChangeLayoutType(newLayout);
                Console.WriteLine("Тип планування оновлено!");
            }

            Console.Write("Введіть новий матеріал стін: ");
            string newMaterial = Console.ReadLine();
            building.ChangeWallMaterial(newMaterial);

            Console.Write("Введіть нову кількість поверхів: ");
            int newFloors = int.Parse(Console.ReadLine());
            building.ChangeFloors(newFloors);

            Console.WriteLine("Будівлю успішно змінено!");
        }

        static void CompareBuildings()
        {
            if (buildings.Count < 2)
            {
                Console.WriteLine("Потрібно щонайменше 2 будівлі для порівняння.");
                return;
            }

            Console.WriteLine("\n=== ПОРІВНЯТИ БУДІВЛІ ===");
            ShowAllBuildings();
            Console.Write("Введіть номер першої будівлі: ");
            int index1 = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Введіть номер другої будівлі: ");
            int index2 = int.Parse(Console.ReadLine()) - 1;

            if (index1 < 0 || index1 >= buildings.Count || index2 < 0 || index2 >= buildings.Count)
            {
                Console.WriteLine("Невірні номери будівель!");
                return;
            }

            var building1 = buildings[index1];
            var building2 = buildings[index2];

            Console.WriteLine($"\nБудівля 1: {building1}");
            Console.WriteLine($"Будівля 2: {building2}");
            Console.WriteLine($"Чи вони однакові? {building1.Equals(building2)}");
        }

        static void DemonstrateVirtualMethod()
        {
            Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ВІРТУАЛЬНОГО МЕТОДУ ===");
            
            // Створюємо масив різних типів будівель
            Building[] buildingArray = new Building[]
            {
                new Building("вул. Тестова 111", "Цегла", 2),
                new ApartmentBuilding("вул. Тестова 222", "Залізобетон", 5, 15),
                new Warehouse("вул. Тестова 333", "Метал", 1, "Напівзакритий"),
                new ApartmentBuilding("вул. Тестова 444", "Камінь", 8, 32),
                new Warehouse("вул. Тестова 555", "Цегла", 3, "Закритий")
            };

            // Демонстрація поліморфізму - кожен об'єкт викликає свою версію ShowInfo
            for (int i = 0; i < buildingArray.Length; i++)
            {
                Console.WriteLine($"\n--- Об'єкт #{i + 1} ({buildingArray[i].GetType().Name}) ---");
                buildingArray[i].ShowInfo();
            }
        }
    }
}