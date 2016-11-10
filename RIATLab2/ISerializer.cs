namespace RIATLab2
{
    public interface ISerializer
    {
        bool CanSerialize(string serializeFormat);
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}
