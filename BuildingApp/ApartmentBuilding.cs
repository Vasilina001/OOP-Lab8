using System;

namespace BuildingManagement
{
    public class ApartmentBuilding : Building
    {
        // Додаткове поле
        private int apartmentsCount;

        // Властивість
        public int ApartmentsCount
        {
            get { return apartmentsCount; }
            set { apartmentsCount = value >= 0 ? value : 0; }
        }

        // Конструктори
        public ApartmentBuilding() : base()
        {
            apartmentsCount = 0;
        }

        public ApartmentBuilding(string address, string wallMaterial, int floors) 
            : base(address, wallMaterial, floors)
        {
            apartmentsCount = 0;
        }

        public ApartmentBuilding(string address, string wallMaterial, int floors, int apartmentsCount) 
            : base(address, wallMaterial, floors)
        {
            this.apartmentsCount = apartmentsCount >= 0 ? apartmentsCount : 0;
        }

        // Конструктор копіювання
        public ApartmentBuilding(ApartmentBuilding other) 
            : base(other)
        {
            this.apartmentsCount = other.apartmentsCount;
        }

        // Метод для зміни кількості квартир
        public void ChangeApartmentsCount(int newCount)
        {
            if (newCount >= 0)
            {
                apartmentsCount = newCount;
            }
        }

        // Перевизначений метод ShowInfo
        public override void ShowInfo()
        {
            Console.WriteLine($"Інформація про житловий будинок:");
            Console.WriteLine($"  Адреса: {address}");
            Console.WriteLine($"  Матеріал стін: {wallMaterial}");
            Console.WriteLine($"  Кількість поверхів: {floors}");
            Console.WriteLine($"  Кількість квартир: {apartmentsCount}");
            Console.WriteLine($"  Кількість квартир: {ApartmentsCount}");
            
            // Тепер все працює, бо використовуємо властивості
            double apartmentsPerFloor = Floors > 0 ? (double)ApartmentsCount / Floors : 0;
            Console.WriteLine($"  Квартир на поверх: {apartmentsPerFloor:F2}");
        }

        // Методи порівняння
        public override bool Equals(object obj)
        {
            if (obj is ApartmentBuilding other)
            {
                return base.Equals(other) && apartmentsCount == other.apartmentsCount;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), apartmentsCount);
        }

        public static bool operator ==(ApartmentBuilding left, ApartmentBuilding right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(ApartmentBuilding left, ApartmentBuilding right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Житловий будинок за адресою {address}, {wallMaterial} стіни, {floors} поверхів, {apartmentsCount} квартир";
        }
    }
}