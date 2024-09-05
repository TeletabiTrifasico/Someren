using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenService
{
    public class OrderService
    {
        OrderDao orderDao;
        private const decimal VAT_9percentCalculation = 0.09m;
        private const decimal VAT_21percentCalculation = 0.21m;
        private const int Vat9Percent = 9;
        private const int Vat21Percent = 21;

        public OrderService()
        {
            orderDao = new();
        }

        /*Order*/

        public void CreateOrder(Student student, Drink drink, int quantity, DateTime dateOfOrder)
        {
            orderDao.CreateOrder(student, drink, quantity, dateOfOrder);
        }

        public void FillOrder(Student student, Drink drink, int quantity)
        {
            DateTime dateOfOrder = DateTime.Now;

            if (drink.Stock < quantity)
            {
                throw new Exception($"Only {drink.Stock} is in stock!");
            }

            orderDao.CreateOrder(student, drink, quantity, dateOfOrder);
        }

        public void DisplayPrice(Drink drink, decimal quantityOfDrinks, out string totalPrice)
        {
            decimal price = drink.Price * quantityOfDrinks;
            totalPrice = $"€{price}";
        }

        /*Revenue*/

        public List<Order> GetOrders()
        {
            return orderDao.GetAll();
        }

        public int CountAmountOfClients(DateTime startDate, DateTime endDate)
        {
            return orderDao.CountAmountOfClients(startDate, endDate);
        }

        public bool RightDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return false;
            }

            return true;
        }

        public void DisplayNumberOfCustomers(DateTime startDate, DateTime endDate, out string numberOfCustomers)
        {
            int studentCount = CountAmountOfClients(startDate, endDate);

            numberOfCustomers = $"{studentCount} Customers";
        }

        public void DisplayTurnover(List<Order> orders, DateTime startDate, DateTime endDate, out string turnover)
        {
            decimal totalRevenue = 0m;

            foreach (var order in orders)
            {
                if (order.OrderDate >= startDate && order.OrderDate <= endDate)
                    totalRevenue += order.Drink.Price * order.Quantity;
            }

            turnover = $"€{totalRevenue} Earned";
        }

        public void DisplayTotalSales(List<Order> orders, DateTime startDate, DateTime endDate, out string totalSales)
        {
            int totalSoldDrinks = 0;

            foreach (var order in orders)
            {
                if (order.OrderDate >= startDate && order.OrderDate <= endDate)
                    totalSoldDrinks += order.Quantity;
            }

            totalSales = $"{totalSoldDrinks} Drinks sold";
        }

        /*VAT*/

        private List<Order> GetAllDrinksByPercent(DateTime startQuarterDate, DateTime endQuarterDate, int percentageVat)
        {
            return orderDao.GetAllDrinksByPercentage(startQuarterDate, endQuarterDate, percentageVat);
        }

        private decimal Count9DrinkPrice(DateTime startDateTime, DateTime endDateTime)
        {
            List<Order> orders9VAT = GetAllDrinksByPercent(startDateTime, endDateTime, Vat9Percent);
            decimal totalPrice9Percent = 0m;

            foreach (var order in orders9VAT)
            {
                totalPrice9Percent += order.Quantity * order.Drink.Price * VAT_9percentCalculation;
            }

            return totalPrice9Percent;
        }

        private decimal Count21DrinkPrice(DateTime startDateTime, DateTime endDateTime)
        {
            List<Order> orders21VAT = GetAllDrinksByPercent(startDateTime, endDateTime, Vat21Percent);
            decimal totalPrice21Percent = 0m;

            foreach (var order in orders21VAT)
            {
                totalPrice21Percent += order.Quantity * order.Drink.Price * VAT_21percentCalculation;
            }

            return totalPrice21Percent;
        }

        private decimal CountTotalPrice(DateTime startDateTime, DateTime endDateTime)
        {
            return Count21DrinkPrice(startDateTime, endDateTime) + Count9DrinkPrice(startDateTime, endDateTime);
        }

        private DateTime CreateDateTime(int year, int quarterNr, bool isStart)
        {
            DateTime startDateTime = new DateTime(year, ((quarterNr - 1) * 3) + 1, 1);
            DateTime endDateTime = startDateTime.AddMonths(3).AddDays(-1);

            return isStart ? startDateTime : endDateTime;
        }

        public void VatInformation(int year, int quarterNumber, out VatInformation information)
        {
            DateTime startDateTime = CreateDateTime(year, quarterNumber, isStart: true);
            DateTime endDateTime = CreateDateTime(year, quarterNumber, isStart: false);

            ShowVAT(startDateTime, endDateTime, out information);
        }

        private static void ShowVAT(DateTime startDateTime, DateTime endDateTime, out VatInformation vatInformation)
        {
            OrderService orderService = new();
            string vat9Percent = orderService.Count9DrinkPrice(startDateTime, endDateTime).ToString("€" + "0.00");
            string vat21Percent = orderService.Count21DrinkPrice(startDateTime, endDateTime).ToString("€" + "0.00");
            decimal totalVAT = orderService.CountTotalPrice(startDateTime, endDateTime);
            string vatTotal = totalVAT.ToString("€" + "0.00");

            vatInformation = new(startDateTime, endDateTime, vat9Percent, vat21Percent, vatTotal);
        }
    }
}