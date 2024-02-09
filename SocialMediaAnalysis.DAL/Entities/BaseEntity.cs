namespace SocialMediaAnalysis.DAL.Entities;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }

    public bool IsDeleted { get; set; }
}