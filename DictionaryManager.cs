public class DictionaryManager
{
    public Dictionary<string, List<string>> Dictionaries { get; private set; }
    private readonly string dicFolder = "./dic";

    public DictionaryManager()
    {
        Dictionaries = new Dictionary<string, List<string>>();
        LoadAll();
    }

    private void LoadAll()
    {
        if (!Directory.Exists(dicFolder))
            Directory.CreateDirectory(dicFolder);

        foreach (var file in Directory.GetFiles(dicFolder, "*.txt"))
        {
            string name = Path.GetFileNameWithoutExtension(file);
            string content = File.ReadAllText(file);

            var items = content
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            Dictionaries[name] = items;
        }
    }

    public List<string> GetDictionary(string name)
    {
        return Dictionaries.ContainsKey(name) ? Dictionaries[name] : null;
    }
}
