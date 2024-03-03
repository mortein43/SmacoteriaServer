namespace SmacoteriaBDFinal.Controls;

public static class EnumControl
{
    public static T GetEnumValueByName<T>(string name) where T : Enum
    {
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            if (value.ToString() == name)
            {
                return value;
            }
        }

        throw new ArgumentException($"Invalid enum name: {name}");
    }
}
