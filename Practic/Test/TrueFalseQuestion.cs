namespace Lab08;

public sealed class TrueFalseQuestion : IQuestion
{
    public string QuestionText { get; }

    public bool CorrectAnswer { get; }

    public TrueFalseQuestion(string questionText, bool correctAnswer)
    {
        if (string.IsNullOrWhiteSpace(questionText))
        {
            throw new ArgumentException("Question text cannot be empty.", nameof(questionText));
        }

        QuestionText = questionText.Trim();
        CorrectAnswer = correctAnswer;
    }

    public void Display(int questionNumber)
    {
        Console.WriteLine();
        Console.WriteLine("Cau " + questionNumber + ": " + QuestionText + " (Y/N)");
    }

    public string ReadValidatedAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon cua ban: ");
            var input = Console.ReadLine();

            bool answer;
            if (TryParseBoolean(input, out answer))
            {
                if (answer)
                {
                    return "Y";
                }

                return "N";
            }

            Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
        }
    }

    public bool IsCorrect(string answer)
    {
        bool parsed;
        if (TryParseBoolean(answer, out parsed) == false)
        {
            return false;
        }

        if (parsed == CorrectAnswer)
        {
            return true;
        }

        return false;
    }

    public string GetAnswerDisplayText(string answer)
    {
        bool parsed;
        if (TryParseBoolean(answer, out parsed) == false)
        {
            return answer;
        }

        if (parsed)
        {
            return "Y";
        }

        return "N";
    }

    public string GetCorrectAnswerText()
    {
        if (CorrectAnswer)
        {
            return "Y";
        }

        return "N";
    }

    private static bool TryParseBoolean(string? input, out bool value)
    {
        value = false;

        if (input == null)
        {
            return false;
        }

        input = input.Trim().ToLower();
        if (input.Length == 0)
        {
            return false;
        }

        if (input == "y" || input == "yes" || input == "true" || input == "t" || input == "1")
        {
            value = true;
            return true;
        }

        if (input == "n" || input == "no" || input == "false" || input == "f" || input == "0")
        {
            value = false;
            return true;
        }

        return false;
    }
}
