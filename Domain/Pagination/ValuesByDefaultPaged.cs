namespace SiniestrosVialesOpitech.Domain.Options.Pagination;
public static class ValuesByDefaultPaged
{
    public const int NumberPage_ByDefault = 1;
    public const int NumberFiles_ByDefault = 10;

    public static int ValidationPageNumber(int pageNumber)
    {
        return (pageNumber != 0)
                ? pageNumber
                : NumberPage_ByDefault;
    }

    public static int ValidationPageSize(int pageSize)
    {
        return (pageSize != 0)
                ? pageSize
                : NumberFiles_ByDefault;
    }
    public const string DIRECCIONORDENAMIENTO = "DESC";
    public const string DIRECCIONORDENAMIENTOASC = "ASC";

}
