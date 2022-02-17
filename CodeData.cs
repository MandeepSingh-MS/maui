class CodeData
{
    [FaunaField("description")]
    public string Description { get; set; }

    [FaunaField("title")]
    public string Title { get; set; }

    [FaunaConstructor]
    public CodeData(string description, string title)
    {
        Description = description;
        Title = title;
    }

}