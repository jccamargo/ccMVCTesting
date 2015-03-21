using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ccMVCTesting.Model
{
    #region "User & UserMetadata"

    //
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    } // User

    // add: [MetadataType(typeof(UserMetadata))] to User class declaration
    public partial class UserMetadata
    {
        [Key]
        public int UserID { get; set; }
        //
        //[Required(ErrorMessage = "{0} is required")]
        [MinLength(5, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(384, ErrorMessage = "{0} must be at most {1} characters")]
        [Display(Name = "Original EMail")]
        [EmailAddress]
        public string OriginalEMail { get; set; }
        //
        //Required(ErrorMessage = "{0} is required")]
        [MinLength(5, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(384, ErrorMessage = "{0} must be at most {1} characters")]
        [Display(Name = "Current EMail")]
        [EmailAddress]
        public string CurrentEMail { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Date Created")]
        public System.DateTimeOffset Created { get; set; }
        //
        [Display(Name = "Date eMail Confirmed")]
        public Nullable<System.DateTimeOffset> Confirmed { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Date Last Updated")]
        public System.DateTimeOffset LastUpdated { get; set; }
        //
        [Display(Name = "Date Last Login")]
        public Nullable<System.DateTimeOffset> LastLogin { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Is user active?")]
        public bool Active { get; set; }
        //
        //[Required(ErrorMessage = "{0} is required")]
        //[MinLength(6, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(1024, ErrorMessage = "{0} must be at most {1} characters")]
        [Display(Name = "Original encoded pwd")]
        public string OriginalPwd { get; set; }
        //
        //[Required(ErrorMessage = "{0} is required")]
        //[MinLength(6, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(1024, ErrorMessage = "{0} must be at most {1} characters")]
        [Display(Name = "Current encoded pwd")]
        public string CurrentPwd { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Failed login attempts")]
        public int FailedAttempts { get; set; }
        //
        [Display(Name = "Default currency for Pockets")]
        public Nullable<int> DefaultCurrencyID { get; set; }
        //
        [Display(Name = "Original registration country")]
        public Nullable<int> OriginalCountryID { get; set; }
        //
        [Display(Name = "Last login country")]
        public Nullable<int> LastLoginCountryID { get; set; }
        //
        [Display(Name = "Last Failed login country")]
        public Nullable<int> LastFailedCountryID { get; set; }
        //
        [Display(Name = "Auth UserID")]
        public string AuthUserID { get; set; }

        // -------

        ////
        //[Display(Name = "Original registration country")]
        //public virtual Country OriginalCountry { get; set; }
        ////
        //[Display(Name = "Last login country")]
        //public virtual Country LastLoginCountry { get; set; }
        ////
        //[Display(Name = "Last Failed login country")]
        //public virtual Country LastFailedCountry { get; set; }
        ////
        //public virtual ICollection<Transaction> Transactions { get; set; }
        ////
        //public virtual ICollection<Session> Sessions { get; set; }
        ////
        //[Display(Name = "Default currency for Pockets")]
        //public virtual Currency DefaultCurrency { get; set; }
        ////
        //public virtual ICollection<Pocket> Pockets { get; set; }

    } // class UserMetadata

    #endregion

    #region "UserEditViewModel & UserEditViewModelMetadata"

    //
    [MetadataType(typeof(UserEditViewModelMetadata))]
    public partial class UserEditViewModel
    {
    } // UserEditViewModel

    // add: [MetadataType(typeof(UserEditViewModelMetadata))] to UserEditViewModel class declaration
    public partial class UserEditViewModelMetadata
    {
        [Key]
        public int UserID { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(5, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(384, ErrorMessage = "{0} must be at most {1} characters")]
        [Display(Name = "Current EMail")]
        public string CurrentEMail { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Is user active?")]
        public bool Active { get; set; }
        //
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Failed login attempts")]
        public int FailedAttempts { get; set; }
        //
        [Display(Name = "Default currency for Pockets")]
        public int? DefaultCurrencyID { get; set; }

        // -------

        //[ScriptIgnore]
        //[Display(Name = "Default currency for Pockets")]
        //public virtual Currency DefaultCurrency { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Category> Categories { get; set; }
        //[ScriptIgnore]
        //public virtual Country LastFailedCountry { get; set; }
        //[ScriptIgnore]
        //public virtual Country LastLoginCountry { get; set; }
        //[ScriptIgnore]
        //public virtual Country OriginalCountry { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Pocket> Pockets { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Provider> Providers { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Session> Sessions { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Supplier> Suppliers { get; set; }
        //[ScriptIgnore]
        //public virtual ICollection<Transaction> Transactions { get; set; }

    } // class UserEditViewModelMetadata

    #endregion

} // namespace
