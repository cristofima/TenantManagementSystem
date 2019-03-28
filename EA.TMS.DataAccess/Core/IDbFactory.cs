namespace EA.TMS.DataAccess.Core
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}