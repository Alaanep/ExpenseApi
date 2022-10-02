using ErrorOr;

namespace RestApi.ServiceErrors{
    public static class Errors{
        public static class Expense{
            public static Error InvalidName => Error.Validation(
                code: "Expense.InvalidName",
                description: $"Expense name must be at least {Models.Expense.MinCategoryLength}" +
                    $" characters long and at most {Models.Expense.MaxCategoryLength} characters long.");

            public static Error InvalidDescription => Error.Validation(
                code: "Expense.InvalidDescription",
                description: $"Expense description must be at least {Models.Expense.MinDescriptionLength}" +
                    $" characters long and at most {Models.Expense.MaxDescriptionLength} characters long."); 

            public static Error NotFound => Error.NotFound(
                code: "Expense.NotFound",
                description: "Expense not found");
        }

         public static class Income{
        public static Error InvalidName => Error.Validation(
            code: "Income.InvalidName",
            description: $"Income name must be at least {Models.Income.MinCategoryLength}" +
                $" characters long and at most {Models.Income.MaxCategoryLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Income.InvalidDescription",
            description: $"Income description must be at least {Models.Income.MinDescriptionLength}" +
                $" characters long and at most {Models.Income.MaxDescriptionLength} characters long."); 

        public static Error NotFound => Error.NotFound(
            code: "Income.NotFound",
            description: "Income not found");
        }
    }
}