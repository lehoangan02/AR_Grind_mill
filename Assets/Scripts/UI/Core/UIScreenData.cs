using System.Collections.Generic;

[System.Serializable]
public class UIScreenData
{
    public Dictionary<string, object> payload;

    public UIScreenData()
    {
        payload = new Dictionary<string, object>();
    }

    public void Set(string key, object value)
    {
        payload[key] = value;
    }

    public T Get<T>(string key)
    {
        if (payload.TryGetValue(key, out object value))
            return (T)value;
        return default(T);
    }

    public bool Has(string key)
    {
        return payload.ContainsKey(key);
    }
}
