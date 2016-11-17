namespace App.Repository.Common
{
    using App.Common.Data;
    using App.Entity.Common;

    public interface ILanguageRepository : IBaseRepository<Language>
    {
        void AddIfNotExist(Language item);
        Language GetByCode(string languageCode);
    }
}
