//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConsituentDishes
    {
        public int ID { get; set; }
        public int DishesID { get; set; }
        public int ProductsID { get; set; }
    
        public virtual Dishes Dishes { get; set; }
        public virtual Products Products { get; set; }
    }
}
