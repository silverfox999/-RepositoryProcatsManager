//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcatsManager.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServicesOrder
    {
        public int IDServicesOrder { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> Service { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Services Services { get; set; }
    }
}
