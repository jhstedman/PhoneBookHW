namespace PhoneBook
{
    public class PhoneBookStorage
    {
        private readonly string LOCATION;

        public PhoneBookStorage(string location)
        {
            LOCATION = location;
            if (!File.Exists(LOCATION))
            {
                var file = File.Create(LOCATION);
                file.Close();
            }
        }

        public Dictionary<string, long> GetNumbers()
        {
            var numbers = new Dictionary<string, long>();
            if (File.Exists(LOCATION))
            {
                numbers  = File.ReadAllLines(LOCATION).ToDictionary(x => x.Split(" ")[0], y => Int64.Parse(y.Split(" ")[1]));
            }
            return numbers;
        }

        public void SaveNumbers(Dictionary<string, long> numbers)
        {
            if (File.Exists(LOCATION))
            {
                var numberList = new List<string>();
                foreach (var number in numbers)
                {
                    numberList.Add($"{number.Key} {number.Value}");
                }
                File.WriteAllLines(LOCATION, numberList);
            }
        }
    }
}