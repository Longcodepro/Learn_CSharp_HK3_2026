namespace Lab08;

public interface IQuestion
{
    string QuestionText { get; }

    void Display(int questionNumber);

    string ReadValidatedAnswer();

    bool IsCorrect(string answer);

    string GetAnswerDisplayText(string answer);

    string GetCorrectAnswerText();
}
