public class StandaloneExpression
{
    public string? Property { get; set; }
    public string? Value { get; set; }
    public string? Operator { get; set; }
}

public class ComposedExpression
{
    public string? FirstTerm { get; set; }
    public string? SecondTerm { get; set; }
    public string? Operator { get; set; }
}

public static class StandaloneExpressionExtensions
{
    public static string AsQuery(this StandaloneExpression standaloneExpression)
     => $"{{\"Data.{standaloneExpression.Property}\": {{\"{standaloneExpression.Operator}\": {standaloneExpression.Value}}}}}";
}

public static class ComposedExpressionExtensions
{
    public static string AsQuery(this ComposedExpression composedExpression)
     => $"{{\"{composedExpression.Operator}\": [{composedExpression.FirstTerm}, {composedExpression.SecondTerm}]}}";
}

public static class EnumExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));
}