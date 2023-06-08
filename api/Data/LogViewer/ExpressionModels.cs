public class StandaloneFilterExpression
{
    public string? Property { get; set; }
    public string? Value { get; set; }
    public string? Operator { get; set; }
}

public class ComposedFilterExpression
{
    public string? FirstTerm { get; set; }
    public string? SecondTerm { get; set; }
    public string? Operator { get; set; }
}

public class StandaloneSortExpression
{
    public string? Property { get; set; }
    public string? Order { get; set; }
}

public class ComposedSortExpression
{
    public string? FirstTerm { get; set; }
    public string? SecondTerm { get; set; }
}

public static class StandaloneFilterExpressionExtensions
{
    public static string AsQuery(this StandaloneFilterExpression standaloneExpression)
     => $"{{\"Data.{standaloneExpression.Property}\": {{\"{standaloneExpression.Operator}\": {standaloneExpression.Value}}}}}";
}

public static class ComposedFilterExpressionExtensions
{
    public static string AsQuery(this ComposedFilterExpression composedExpression)
     => $"{{\"{composedExpression.Operator}\": [{composedExpression.FirstTerm}, {composedExpression.SecondTerm}]}}";
}

public static class StandaloneSortExpressionExtensions
{
    public static string AsPreQuery(this StandaloneSortExpression standaloneExpression)
     => $"\"Data.{standaloneExpression.Property}\": {standaloneExpression.Order}";

    public static string AsQuery(this StandaloneSortExpression standaloneExpression)
     => $"{{\"Data.{standaloneExpression.Property}\": {standaloneExpression.Order}}}";
}

public static class ComposedSortExpressionExtensions
{
    public static string AsPreQuery(this ComposedSortExpression composedExpression)
     => $"{composedExpression.FirstTerm}, {composedExpression.SecondTerm}";

    public static string AsQuery(this ComposedSortExpression composedExpression)
     => $"{{{composedExpression.FirstTerm}, {composedExpression.SecondTerm}}}";

}

public static class EnumExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));
}