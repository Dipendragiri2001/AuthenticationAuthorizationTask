using InficareTask.Models;
namespace InficareTask
{
    public class BankInitializer
    {
        //Creates list of bank objects and returns banks
        public List<Bank> GetBanks()
        {
            List<Bank> banks = new List<Bank>();

            banks.Add(new Bank{Name = "Nabil Bank"});
            banks.Add(new Bank{Name = "NIC Asia Bank"});
            banks.Add(new Bank{Name = "Nepal Investment Bank"});

            return banks;
        }
    }
}