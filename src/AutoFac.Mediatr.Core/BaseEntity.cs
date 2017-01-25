using System;

namespace AutoFac.Mediatr.Core
{
    public abstract class BaseEntity
    {
        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual Guid Id { get; set; }
        public bool InActive { get; set; }

        public DateTime? InActiveOn { get; set; }

        // maxlength: 256
        public string InActiveReason { get; set; }

        public virtual Guid? ModifiedBy { get; set; }

        public virtual DateTime? ModifiedOn { get; set; }

        // maxlength: 2000
        public string Notes { get; set; }
    }
}