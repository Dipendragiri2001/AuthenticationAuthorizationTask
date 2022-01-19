using InficareTask.Models;
namespace InficareTask
{
    public class CustomerInitializer
    {
         //Creates list of customer objects and returns customers
        public List<Customer> GetCustomers()
        {
             List<Customer> customers = new List<Customer>();

            customers.Add(new Customer{Name = "Nabil Bank"});
            customers.Add(new Customer{Name = "NIC Asia Bank"});
            customers.Add(new Customer{Name = "Nepal Investment Bank"});

            return customers;
        }
    }
}