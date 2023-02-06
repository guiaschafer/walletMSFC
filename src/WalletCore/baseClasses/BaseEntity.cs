public class BaseEntity
{
    public Guid Id;
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreateAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }

    public virtual void Validate() {}
    
}