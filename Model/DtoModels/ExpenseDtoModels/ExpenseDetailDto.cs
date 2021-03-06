namespace Model.DtoModels.ExpenseDtoModels
{
    public class ExpenseDetailDto
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public int ExpenseItemId { get; set; }
        public string ExpenseItemName { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Note { get; set; }


    }
}
