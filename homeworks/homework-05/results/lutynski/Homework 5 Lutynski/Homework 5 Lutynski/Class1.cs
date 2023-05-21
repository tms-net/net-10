using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Lutynski
{
    // структура торговой компании
    public interface IStorageWorker
    {
        internal void ReceiveProduct();
        internal void FillOrder();
    }
    public interface IOfiiceWorker
    {
        internal void StartWork();
        internal void FinishWork();
        
    }
    internal abstract class Company : IOfiiceWorker, IStorageWorker
    {
        internal bool PCIsTurnedOn;

        internal Company(string salary, string workingSchedule, string employee)
        {
            Employee = employee;
            Salary = salary;
            WorkingSchedule = workingSchedule;
        }

        public string Employee { get; set; }
        public string Salary { get; set; }
        public string WorkingSchedule { get; set; }
        public virtual void StartWork()
        {
            PCIsTurnedOn = true;
        }
        public void FinishWork()
        {
            PCIsTurnedOn = false;
        }
        public void ReceiveProduct()
        {
            Console.WriteLine("Принять товар на склад");
        }
        public void FillOrder()
        {
            Console.WriteLine("Собрать заказ");
        }
    }
    internal class SalesDeptEmployee : Company, IOfiiceWorker
    {
        internal SalesDeptEmployee(string salary, string workingSchedule, string employee) : base(salary, workingSchedule, employee)
        {
            this.Employee = employee;
            this.Salary = salary;
            this.WorkingSchedule = workingSchedule;
        }
        public override void StartWork()
        {
            base.StartWork();
            Console.WriteLine("Проверить почту");
        }
    }
    internal class SupplyDeptEmployee : Company, IOfiiceWorker
    {
        internal SupplyDeptEmployee(string salary, string workingSchedule, string employee) : base(salary, workingSchedule, employee)
        {
        }
        public override void StartWork()
        {
            base.StartWork();
            Console.WriteLine("Проверить остатки товара на складе");
        }
    }
    internal class AccountOfficeEmployee : Company, IOfiiceWorker
    {
        internal AccountOfficeEmployee(string salary, string workingSchedule, string employee) : base(salary, workingSchedule, employee)
        {
        }

        public override void StartWork()
        {
            base.StartWork();
            Console.WriteLine("Разнести поступившие оплаты");
        }
    }
    internal abstract class StorageEmployee : Company, IStorageWorker 
    {
        internal StorageEmployee(string salary, string workingSchedule, string employee) : base(salary, workingSchedule, employee)
        {
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesDeptEmployee employee = new SalesDeptEmployee("1000", "9-6", "Stas");
            
            employee.StartWork();



        }
    }
}
