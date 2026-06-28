using System;
using System.Collections;
namespace Lab01.Bai4;

enum AccountType
{
    Saving,
    Checking,
    Credit
}

class Transaction
{
    public string Type{set; get;}
    public decimal Amount{set; get;}
    public DateTime Date{set; get;}

    public Transaction(string type, decimal amount)
    {
        Type = type;
        Amount = amount;
        Date = DateTime.Now;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Type: {Type} | Amount: {Amount:N0} | Date: {Date}");
    }
}

abstract class BankAccount
{
    public string AccountNumber{set; get;}
    public string Holder{set; get;}
    public decimal Balance{set; get;}
    public AccountType Type{set; get;}
    private List<Transaction> listTransaction = new List<Transaction>();

    public BankAccount(string accountNumber, string holder, decimal balance, AccountType type)
    {
        AccountNumber = accountNumber;
        Holder = holder;
        Balance = balance;
        Type = type;
    }

    public void Deposit(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("[ERROR] Số tiền nạp phải lớn hơn 0");
            return;
        }
        Balance += amount;
        listTransaction.Add(new Transaction("Deposit", amount));
        Console.WriteLine($"[NOTICE] Nạp {amount:N0} thành công | Số dư hiện tại: {Balance:N0}");
    }

    public abstract bool Withdraw(decimal amount);

    public void Transfer(BankAccount target, decimal amount)
    {
        Console.WriteLine($"[NOTICE] Đang chuyển {amount:N0} từ {Holder} sang {target.Holder}");
        bool success = Withdraw(amount);
        if(success)
        {
            target.Deposit(amount);
            Console.WriteLine($"[OK] Chuyển tiền thành công!");
        }
        else
        {
            Console.WriteLine($"[ERROR] Chuyển tiền thất bại!");
        }
    }

    protected void AddTransaction(Transaction transaction)
    {
        listTransaction.Add(transaction);
    }

    public void PrintHistory()
    {
        Console.WriteLine($"[Lịch sử giao dịch của {Holder}]");
        foreach(Transaction item in listTransaction)
        {
            item.PrintInfo();
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"AccountNumber: {AccountNumber} | Holder: {Holder} | Balance: {Balance:N0} | Type: {Type}");
    }
}

class SavingAccount : BankAccount
{
    public SavingAccount(string accountNumber, string holder, decimal balance)
        : base(accountNumber, holder, balance, AccountType.Saving) {}

    public override bool Withdraw(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("[ERROR] Số tiền rút phải lớn hơn 0");
            return false;
        }
        if(amount > Balance)
        {
            Console.WriteLine($"[ERROR] Số dư không đủ | Số dư hiện tại: {Balance:N0}");
            return false;
        }
        Balance -= amount;
        AddTransaction(new Transaction("Withdraw", amount));
        Console.WriteLine($"[NOTICE] Rút {amount:N0} thành công | Số dư hiện tại: {Balance:N0}");
        return true;
    }
}

class CheckingAccount : BankAccount
{
    private decimal _overdraftLimit = 5000000;

    public CheckingAccount(string accountNumber, string holder, decimal balance)
        : base(accountNumber, holder, balance, AccountType.Checking) {}

    public override bool Withdraw(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("[ERROR] Số tiền rút phải lớn hơn 0");
            return false;
        }
        if(amount > Balance + _overdraftLimit)
        {
            Console.WriteLine($"[ERROR] Vượt quá hạn mức chi {_overdraftLimit:N0}");
            return false;
        }
        Balance -= amount;
        AddTransaction(new Transaction("Withdraw", amount));
        Console.WriteLine($"[NOTICE] Rút {amount:N0} thành công | Số dư hiện tại: {Balance:N0}");
        return true;
    }
}

class CreditAccount : BankAccount
{
    private decimal _creditLimit = 10000000;

    public CreditAccount(string accountNumber, string holder)
        : base(accountNumber, holder, 0, AccountType.Credit) {}

    public override bool Withdraw(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("[ERROR] Số tiền rút phải lớn hơn 0");
            return false;
        }
        if(amount > _creditLimit + Balance)
        {
            Console.WriteLine($"[ERROR] Vượt quá hạn mức tín dụng {_creditLimit:N0}");
            return false;
        }
        Balance -= amount;
        AddTransaction(new Transaction("Withdraw", amount));
        Console.WriteLine($"[NOTICE] Rút {amount:N0} thành công | Số dư hiện tại: {Balance:N0}");
        return true;
    }
}

class Bank_Account
{
    public static void Main(string[] args)
    {

        Console.WriteLine("==========SavingAccount==========");
        SavingAccount saving1 = new SavingAccount("ACC001", "Nguyen Van A", 10000000);
        SavingAccount saving2 = new SavingAccount("ACC002", "Nguyen Van B", 5000000);
        saving1.PrintInfo();
        saving2.PrintInfo();

        Console.WriteLine("--------------Deposit----------------");
        saving1.Deposit(2000000);
        saving1.Deposit(-500000);

        Console.WriteLine("--------------Withdraw----------------");
        saving1.Withdraw(3000000);
        saving1.Withdraw(99000000);

        Console.WriteLine("--------------Transfer----------------");
        saving1.Transfer(saving2, 1000000);
        saving1.Transfer(saving2, 99000000);

        Console.WriteLine("--------------History----------------");
        saving1.PrintHistory();

        Console.WriteLine("==========CheckingAccount==========");
        CheckingAccount checking1 = new CheckingAccount("ACC003", "Tran Van C", 5000000);
        CheckingAccount checking2 = new CheckingAccount("ACC004", "Tran Van D", 3000000);
        checking1.PrintInfo();
        checking2.PrintInfo();

        Console.WriteLine("--------------Deposit----------------");
        checking1.Deposit(1000000);

        Console.WriteLine("--------------Withdraw----------------");
        checking1.Withdraw(8000000);
        checking1.Withdraw(99000000);

        Console.WriteLine("--------------Transfer----------------");
        checking1.Transfer(checking2, 1000000);
        checking1.Transfer(checking2, 99000000);

        Console.WriteLine("--------------History----------------");
        checking1.PrintHistory();

        Console.WriteLine("==========CreditAccount==========");
        CreditAccount credit1 = new CreditAccount("ACC005", "Le Van E");
        CreditAccount credit2 = new CreditAccount("ACC006", "Le Van F");
        credit1.PrintInfo();
        credit2.PrintInfo();

        Console.WriteLine("--------------Deposit----------------");
        credit1.Deposit(2000000);

        Console.WriteLine("--------------Withdraw----------------");
        credit1.Withdraw(5000000);
        credit1.Withdraw(99000000);

        Console.WriteLine("--------------Transfer----------------");
        credit1.Transfer(credit2, 1000000);
        credit1.Transfer(credit2, 99000000);

        Console.WriteLine("--------------History----------------");
        credit1.PrintHistory();
    }
}
