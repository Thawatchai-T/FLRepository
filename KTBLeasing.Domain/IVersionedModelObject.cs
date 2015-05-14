namespace KTBLeasing.FrontLeasing.Domain
{
    public interface IVersionedModelObject
    {
        byte[] Version { get; set; }
    }
}