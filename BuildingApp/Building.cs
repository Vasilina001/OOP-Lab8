using System;

namespace BuildingManagement
{
    public class Building
    {
        // Поля
        protected string address;
        protected string wallMaterial;
        protected int floors;

        // Властивості
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string WallMaterial
        {
            get { return wallMaterial; }
            set { wallMaterial = value; }
        }

        public int Floors
        {
            get { return floors; }
            set { floors = value >= 0 ? value : 0; }
        }

        // Конструктори
        public Building()
        {
            address = "Невідома";
            wallMaterial = "Цегла";
            floors = 1;
        }

        public Building(string address, string wallMaterial)
        {
            this.address = address;
            this.wallMaterial = wallMaterial;
            this.floors = 1;
        }

        public Building(string address, string wallMaterial, int floors)
        {
            this.address = address;
            this.wallMaterial = wallMaterial;
            this.floors = floors >= 0 ? floors : 0;
        }

        // Конструктор копіювання
        public Building(Building other)
        {
            this.address = other.address;
            this.wallMaterial = other.wallMaterial;
            this.floors = other.floors;
        }

        // Методи для зміни властивостей
        public void ChangeWallMaterial(string newMaterial)
        {
            if (!string.IsNullOrEmpty(newMaterial))
            {
                wallMaterial = newMaterial;
            }
        }

        public void ChangeFloors(int newFloors)
        {
            if (newFloors >= 0)
            {
                floors = newFloors;
            }
        }

        // Віртуальний метод для відображення інформації
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Інформація про будівлю:");
            Console.WriteLine($"  Адреса: {address}");
            Console.WriteLine($"  Матеріал стін: {wallMaterial}");
            Console.WriteLine($"  Кількість поверхів: {floors}");
        }

        // Методи порівняння
        public override bool Equals(object obj)
        {
            if (obj is Building other)
            {
                return address == other.address && 
                       wallMaterial == other.wallMaterial && 
                       floors == other.floors;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(address, wallMaterial, floors);
        }

        public static bool operator ==(Building left, Building right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Building left, Building right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Будівля за адресою {address}, {wallMaterial} стіни, {floors} поверхів";
        }
    }
}