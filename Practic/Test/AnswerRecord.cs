namespace Lab08;

public sealed class AnswerRecord
{
    public int QuestionNumber { get; }

    public string QuestionText { get; }

    public string StudentAnswer { get; }

    public string CorrectAnswer { get; }

    public bool IsCorrect { get; }

    public AnswerRecord(int questionNumber, string questionText, string studentAnswer, string correctAnswer, bool isCorrect)
    {
        QuestionNumber = questionNumber;
        QuestionText = questionText;
        StudentAnswer = studentAnswer;
        CorrectAnswer = correctAnswer;
        IsCorrect = isCorrect;
    }
}
