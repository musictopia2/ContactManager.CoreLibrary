namespace ContactManager.CoreLibrary.Attributes;
public class EnsureOneElementAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is ICountCollection list)
        {
            return list.Count > 0;
        }
        return false;
    }
}