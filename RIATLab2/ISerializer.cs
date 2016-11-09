namespace RIATLab2
{
    public interface ISerializer
    {
        bool CanSerialize(string serializeFormat);
        byte[] Serialize<T>(T obj);
        T Deserialize<T>(byte[] serializedObj);
    }
}
