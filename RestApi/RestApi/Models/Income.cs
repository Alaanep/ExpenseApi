namespace RestApi.Models{
    public record Income{
        public const  int MinCategoryLength=3;
        public const int MaxCategoryLength = 50;
        public const  int MinDescriptionLength=3;
        public const int MaxDescriptionLength = 50;
        public Guid Id {get; init;}
        public string Description {get; init;}
        public string Category {get; init;}
        public decimal Amount {get; init;}
        public DateTimeOffset Date{get ;init;}
    }
}

// using RestApi.ServiceErrors;
// using ErrorOr;
// using RestApi.Contracts.Incomes;
// namespace RestApi.Models{
//     public class Income{
//         public const  int MinCategoryLength=3;
//         public const int MaxCategoryLength = 50;
//         public const  int MinDescriptionLength=3;
//         public const int MaxDescriptionLength = 50;
//         public Guid Id {get; init;}
//         public string Description {get; init;}
//         public string Category {get; init;}
//         public decimal Amount {get; init;}
//         public DateTimeOffset Date{get ;init;}
        

//         public Income(
//             Guid id,
//             string description,
//             string category,
//             decimal amount,
//             DateTimeOffset date

//         ){
//             Id=id;
//             Description=description;
//             Category=category;
//             Amount=amount;
//             Date=date;

//         }

//         public static ErrorOr<Income> Create(
//             string description,
//             string category,
//             decimal amount,
//             DateTimeOffset date,
//             Guid? id= null
//         ){  
//             List<Error> errors = new ();
//             //enforce invariants
//             if(category.Length is < MinCategoryLength or >  MaxCategoryLength){
//                 errors.Add(Errors.Income.InvalidName);
//             }

//             if(description.Length is < MinDescriptionLength or > MaxDescriptionLength){
//                 errors.Add(Errors.Income.InvalidDescription);
//             }

//             if(errors.Count>0){
//                  return errors;
//             }

//             return new Income(
//                 id ?? Guid.NewGuid(),
//                 description,
//                 category,
//                 amount,
//                 date 
//             );
//         }

//         public static ErrorOr<Income> From(CreateIncomeRequest request){
//             return Create(
//                 request.Description,
//                 request.Category,
//                 request.Amount,
//                 request.Date
//             );
//         }

//         public static ErrorOr<Income> From(Guid id, UpsertIncomeRequest request){
//             return Create(
//                 request.Description,
//                 request.Category,
//                 request.Amount,
//                 request.Date,
//                 id
//             );
//         }
//     }
// }