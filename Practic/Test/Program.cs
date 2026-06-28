using Lab08;

var bank = new QuestionBank<IQuestion>();
bank.Add(new MultipleChoiceQuestion(
    "Tu khoa nao dung de khai bao class trong C#?",
    new[] { "struct", "class", "object", "method" },
    2));

bank.Add(new TrueFalseQuestion(
    "C# la ngon ngu lap trinh huong doi tuong?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa nao dung de tao mot doi tuong tu class?",
    new[] { "new", "create", "make", "build" },
    1));

bank.Add(new TrueFalseQuestion(
    "Interface co the chua field co gia tri mac dinh?",
    false));

bank.Add(new MultipleChoiceQuestion(
    "Collection nao luu duoc ca key va value?",
    new[] { "List<T>", "Dictionary<TKey, TValue>", "Stack<T>", "Queue<T>" },
    2));

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa nao dung de ke thua trong C#?",
    new[] { "implements", "extends", ":", "inherits" },
    3));

bank.Add(new TrueFalseQuestion(
    "Array trong C# co do dai co dinh sau khi khoi tao?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "Phuong thuc nao duoc goi khi tao doi tuong moi?",
    new[] { "Destructor", "Constructor", "Indexer", "Property" },
    2));

bank.Add(new TrueFalseQuestion(
    "List<T> la generic collection trong .NET?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa nao dung de bat ngoai le?",
    new[] { "try", "catch", "throw", "finally" },
    1));

var quiz = new Quiz(bank.GetAll());
quiz.Run();
