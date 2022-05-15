namespace PhoneBook
{
    public class PhoneBookClass
    {
        private readonly PhoneBookStorage _storage;
        private Dictionary<string, long> _phoneNumbers;

        public PhoneBookClass(PhoneBookStorage storage)
        {
            _storage = storage;
            _phoneNumbers = _storage.GetNumbers();
        }

        public void Store(string name, string number)
        {
            name = ShortenName(name);
            if (!_phoneNumbers.ContainsKey(name))
            {
                _phoneNumbers.Add(name, Int64.Parse(number));
                _storage.SaveNumbers(_phoneNumbers);
            }
            else
            {
                _phoneNumbers[name] = Int64.Parse(number);
                _storage.SaveNumbers(_phoneNumbers);
            }
        }

        public string Get(string name)
        {
            name = ShortenName(name);
            if (_phoneNumbers.ContainsKey(name))
            {
                return $"{_phoneNumbers[name]:00000000000}";
            }
            else
            {
                return "NaN";
            }
        }

        public string RemoveByName(string name)
        {
            var number = Get(name);
            name = ShortenName(name);
            if (_phoneNumbers.ContainsKey(name))
            {
                _phoneNumbers.Remove(name);
                _storage.SaveNumbers(_phoneNumbers);
            }
            return number;
        }

        public string Update(string name, string number)
        {
            var oldNumber = Get(name);
            name = ShortenName(name);
            if (_phoneNumbers.ContainsKey(name))
            {
                _phoneNumbers[name] = Int64.Parse(number);
                _storage.SaveNumbers(_phoneNumbers);
            }
            return oldNumber;
        }

        public void RemoveByNumber(string number)
        {
            foreach(var item in _phoneNumbers.Where(x => x.Value == Int64.Parse(number)).ToList())
            {
                _phoneNumbers.Remove(item.Key);
            }
        }

        private string ShortenName(string name)
        {
            var shortName = "";
            char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
            var upperName = name.ToUpper();
            foreach(var letter in upperName)
            {
                if(Array.IndexOf(vowels, letter) == -1)
                {
                    shortName += letter;
                }
            }
            if(shortName.Length > 4) 
            { 
                shortName = shortName.Substring(0, 4);
            }
            return shortName;
        }
    }
}