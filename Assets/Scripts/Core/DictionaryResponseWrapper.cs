[System.Serializable]
public class DictionaryResponseWrapper
{
    public Entry[] entries;
}

[System.Serializable]
public class Entry
{
    public Meaning[] meanings;
}

[System.Serializable]
public class Meaning
{
    public Definition[] definitions;
}

[System.Serializable]
public class Definition
{
    public string definition;
}