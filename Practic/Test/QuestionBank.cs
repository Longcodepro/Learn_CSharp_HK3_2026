namespace Lab08;

public sealed class QuestionBank<T> where T : IQuestion
{
    private readonly List<T> _questions = new();

    public void Add(T question)
    {
        _questions.Add(question);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _questions.AsReadOnly();
    }
}
