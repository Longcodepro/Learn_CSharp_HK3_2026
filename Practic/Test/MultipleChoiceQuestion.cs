namespace Lab08;

public sealed class MultipleChoiceQuestion : IQuestion
{
    private readonly List<string> _options;

    public string QuestionText { get; }

    public IReadOnlyList<string> Options
    {
        get { return _options.AsReadOnly(); }
    }

    public int CorrectOptionIndex { get; }

    public MultipleChoiceQuestion(string questionText, IEnumerable<string> options, int correctOptionIndex)
    {
        if (string.IsNullOrWhiteSpace(questionText))
        {
            throw new ArgumentException("Question text cannot be empty.", nameof(questionText));
        }

        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        _options = new List<string>();
        foreach (var option in options)
        {
            if (option == null)
            {
                _options.Add(string.Empty);
            }
            else
            {
                _options.Add(option.Trim());
            }
        }

        if (_options.Count <= 1)
        {
            throw new ArgumentException("Question must have at least 2 options.", nameof(options));
        }

        for (var i = 0; i < _options.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(_options[i]))
            {
                throw new ArgumentException("Options cannot be empty.", nameof(options));
            }
        }

        if (correctOptionIndex < 1 || correctOptionIndex > _options.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(correctOptionIndex));
        }

        QuestionText = questionText.Trim();
        CorrectOptionIndex = correctOptionIndex;
    }

    public void Display(int questionNumber)
    {
        Console.WriteLine();
        Console.WriteLine("Cau " + questionNumber + ": " + QuestionText);

        for (var i = 0; i < _options.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _options[i]);
        }
    }

    public string ReadValidatedAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon cua ban: ");
            var input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
                continue;
            }

            input = input.Trim();
            if (input.Length == 0)
            {
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
                continue;
            }

            int choice;
            if (int.TryParse(input, out choice) == false)
            {
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
                continue;
            }

            if (choice < 1 || choice > _options.Count)
            {
                Console.WriteLine("Lua chon nam ngoai pham vi. Vui long nhap lai.");
                continue;
            }

            return choice.ToString();
        }
    }

    public bool IsCorrect(string answer)
    {
        int choice;
        if (int.TryParse(answer, out choice) == false)
        {
            return false;
        }

        if (choice == CorrectOptionIndex)
        {
            return true;
        }

        return false;
    }

    public string GetAnswerDisplayText(string answer)
    {
        int choice;
        if (int.TryParse(answer, out choice) == false)
        {
            return answer;
        }

        if (choice < 1 || choice > _options.Count)
        {
            return answer;
        }

        return choice + ". " + _options[choice - 1];
    }

    public string GetCorrectAnswerText()
    {
        return CorrectOptionIndex + ". " + _options[CorrectOptionIndex - 1];
    }
}
