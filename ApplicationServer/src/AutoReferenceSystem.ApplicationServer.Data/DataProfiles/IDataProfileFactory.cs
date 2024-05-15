using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;


namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public interface IDataProfileFactory
    {
        DataProfile CreateProfile();
    }
}
