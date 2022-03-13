namespace GRHWLibrary
{
    public interface ISomeDataProvider<T>
    {
        List<T> GetData(ISomeFileHandler fileReader, char delimiter);

    }
}
