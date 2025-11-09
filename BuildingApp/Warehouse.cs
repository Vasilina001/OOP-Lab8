using System;

namespace BuildingManagement
{
    public class Warehouse : Building
    {
        // Додаткове поле
        private string layoutType;

        // Властивість
        public string LayoutType
        {
            get { return layoutType; }
            set 
            { 
                if (value == "Відкритий" || value == "Закритий" || value == "Напівзакритий")
                    layoutType = value;
                else
                    layoutType = "Відкритий";
            }
        }

        // Конструктори
        public Warehouse() : base()
        {
            layoutType = "Відкритий";
        }

        public Warehouse(string address, string wallMaterial, int floors) 
            : base(address, wallMaterial, floors)
        {
            layoutType = "Відкритий";
        }

        public Warehouse(string address, string wallMaterial, int floors, string layoutType) 
            : base(address, wallMaterial, floors)
        {
            LayoutType = layoutType; // Використання властивості для валідації
        }

        // Конструктор копіювання
        public Warehouse(Warehouse other) 
            : base(other)
        {
            this.layoutType = other.layoutType;
        }

        // Метод для зміни типу планування
        public void ChangeLayoutType(string newLayoutType)
        {
            LayoutType = newLayoutType; // Використання властивості для валідації
        }

        // Перевизначений метод ShowInfo
        public override void ShowInfo()
        {
            Console.WriteLine($"Інформація про склад:");
            Console.WriteLine($"  Адреса: {address}");
            Console.WriteLine($"  Матеріал стін: {wallMaterial}");
            Console.WriteLine($"  Кількість поверхів: {floors}");
            Console.WriteLine($"  Тип планування: {layoutType}");
            Console.WriteLine($"  Місткість складу: {CalculateStorageCapacity()} одиниць");
        }

        private int CalculateStorageCapacity()
        {
            int baseCapacity = floors * 1000;
            return layoutType switch
            {
                "Відкритий" => baseCapacity,
                "Закритий" => (int)(baseCapacity * 1.5),
                "Напівзакритий" => (int)(baseCapacity * 1.2),
                _ => baseCapacity
            };
        }

        // Методи порівняння
        public override bool Equals(object obj)
        {
            if (obj is Warehouse other)
            {
                return base.Equals(other) && layoutType == other.layoutType;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), layoutType);
        }

        public static bool operator ==(Warehouse left, Warehouse right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Warehouse left, Warehouse right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Склад за адресою {address}, {wallMaterial} стіни, {floors} поверхів, {layoutType} планування";
        }
    }
}