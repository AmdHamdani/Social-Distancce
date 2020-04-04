public class ValueUtil
{
    public static T DefaultClass<T>() where T : class, new()
    {
        return new T();
    }

    public static T DefaultStruct<T>() where T : struct
    {
        return new T();
    }
}
