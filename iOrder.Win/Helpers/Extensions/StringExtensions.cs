namespace iOrder.Win.Helpers.Extensions
{
  public static class StringExtensions
  {
    public static bool IsNullOrEmpty(this string source)
    {
      return string.IsNullOrEmpty(source) & string.IsNullOrWhiteSpace(source);
    }

    public static bool IsNotNullOrEmpty(this string source)
    {
      return !source.IsNullOrEmpty();
    }
  }
}
