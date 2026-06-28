namespace Lab08;

public sealed class Quiz
{
    private readonly IReadOnlyList<IQuestion> _questions;

    private readonly List<AnswerRecord> _records = new();

    public Quiz(IEnumerable<IQuestion> questions)
    {
        if (questions == null)
        {
            throw new ArgumentNullException(nameof(questions));
        }

        _questions = questions.ToList();
    }

    public void Run()
    {
        Console.WriteLine("===== QUIZ CONSOLE APP =====");

        for (var i = 0; i < _questions.Count; i++)
        {
            var question = _questions[i];
            question.Display(i + 1);

            var answer = question.ReadValidatedAnswer();
            var isCorrect = question.IsCorrect(answer);

            var record = new AnswerRecord(
                i + 1,
                question.QuestionText,
                question.GetAnswerDisplayText(answer),
                question.GetCorrectAnswerText(),
                isCorrect);

            _records.Add(record);

            if (isCorrect)
            {
                Console.WriteLine("Ket qua: Dung!");
            }
            else
            {
                Console.WriteLine("Ket qua: Sai!");
            }
        }

        PrintSummary();
    }

    private void PrintSummary()
    {
        var total = _records.Count;
        var correctCount = 0;

        for (var i = 0; i < _records.Count; i++)
        {
            if (_records[i].IsCorrect)
            {
                correctCount++;
            }
        }

        var wrongCount = total - correctCount;
        var score = correctCount;
        var percent = 0.0;

        if (total > 0)
        {
            percent = (double)correctCount / total * 100;
        }

        var classification = GetClassification(percent);

        Console.WriteLine();
        Console.WriteLine("===== KET QUA =====");
        Console.WriteLine("Tong so cau: " + total);
        Console.WriteLine("So cau dung: " + correctCount);
        Console.WriteLine("So cau sai: " + wrongCount);
        Console.WriteLine("Diem cuoi cung: " + score + "/" + total);
        Console.WriteLine("Xep loai: " + classification);

        PrintRecentWrongAnswers();
        PrintLongestCorrectStreak();
    }

    private void PrintRecentWrongAnswers()
    {
        var recentWrongAnswers = new List<AnswerRecord>();

        for (var i = _records.Count - 1; i >= 0; i--)
        {
            if (_records[i].IsCorrect == false)
            {
                recentWrongAnswers.Add(_records[i]);
            }

            if (recentWrongAnswers.Count == 3)
            {
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("3 cau sai gan nhat:");

        if (recentWrongAnswers.Count == 0)
        {
            Console.WriteLine("- Khong co cau tra loi sai nao.");
            return;
        }

        for (var i = 0; i < recentWrongAnswers.Count; i++)
        {
            var record = recentWrongAnswers[i];
            Console.WriteLine("- Cau " + record.QuestionNumber + ": " + record.QuestionText + " | Ban chon: " + record.StudentAnswer + " | Dap an dung: " + record.CorrectAnswer);
        }
    }

    private void PrintLongestCorrectStreak()
    {
        var bestStart = -1;
        var bestLength = 0;
        var currentStart = -1;
        var currentLength = 0;

        for (var i = 0; i < _records.Count; i++)
        {
            if (_records[i].IsCorrect)
            {
                if (currentLength == 0)
                {
                    currentStart = i;
                }

                currentLength++;

                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestStart = currentStart;
                }
            }
            else
            {
                currentLength = 0;
                currentStart = -1;
            }
        }

        Console.WriteLine();

        if (bestLength == 0)
        {
            Console.WriteLine("Doan dung lien tiep dai nhat: khong co cau tra loi dung nao.");
            return;
        }

        var bestEnd = bestStart + bestLength - 1;
        Console.WriteLine("Doan dung lien tiep dai nhat: tu cau " + _records[bestStart].QuestionNumber + " den cau " + _records[bestEnd].QuestionNumber + ", tong cong " + bestLength + " cau.");
    }

    private static string GetClassification(double percent)
    {
        if (percent >= 80)
        {
            return "Gioi";
        }

        if (percent >= 65)
        {
            return "Kha";
        }

        if (percent >= 50)
        {
            return "Trung binh";
        }

        return "yếu";
    }
}
