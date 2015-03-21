using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
//using System.Web.Script.Serialization;

namespace ccMVCTesting.Model
{
    // fields on this class are not mapped into the database by Entity Framework
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

        #region "additionals for: color handling aid to color pickers, etc"

        private const string NO_COLOR = "#00654321";
        //
        private Color _color = System.Drawing.ColorTranslator.FromHtml(NO_COLOR);
        //
        private string _color_hex = "";

        //
        private string AsHexClr(int clr)
        {
            string hex = clr.ToString("X").ToLower();
            // cut "ff" in alpha
            if ((hex.Length == 8) && (hex.StartsWith("ff")))
                hex = hex.Substring(2);
            //
            if (hex.Length < 7)
                hex = hex.PadLeft(6, '0');
            //
            return "#" + hex;
            //
        }

        // like ##AARRGGBB
        // #00ffBB88
        [Required]
        [Display(Name = "Category Color")]
        public string CategoryColorStr
        {
            get
            {
                if (_color_hex == "")
                    _color_hex = AsHexClr(this.CategoryColor);
                //
                return _color_hex;
                //
            }
            //
            set
            {
                try
                {
                    // if color changing
                    Color xcolor = System.Drawing.ColorTranslator.FromHtml(value);
                    if (xcolor != _color)
                    {
                        _color = xcolor;
                        this.CategoryColor = _color.ToArgb();
                        _color_hex = AsHexClr(this.CategoryColor);
                    }
                }
                catch (Exception ex)
                {
                    ex.GetType();
                }
            }
            //
        } // CategoryColorStr

        #endregion

    } // Category

    // metadata
    // add: [MetadataType(typeof(CategoryMetadata))] to Category class declaration
    public partial class CategoryMetadata
    {
        [Key]
        public int CategoryID;
        [Required]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters")]
        [MaxLength(64, ErrorMessage = "{0} must be at most {1} characters")]
        //[ExcludeChar("@#$%'\"", "{0} contains invalid character.")]
        [Display(Name = "Category Name", Prompt = "category name")]
        public string CategoryName;
        //
        [Display(Name = "Parent Category")]
        public int? ParentCategoryID { get; set; }
        //
        [Display(Name = "Category Color")]
        public int CategoryColor;
        //
        [Required]
        [Display(Name = "User")]
        public int UserID { get; set; }
        //
        [Display(Name = "Parent Category")]
        public string ParentCategoryName { get; set; }

        // -------

        //[ScriptIgnore]
        public virtual User User { get; set; }
        ////[ScriptIgnore]
        //public virtual ICollection<Transaction> Transactions { get; set; }
        ////[ScriptIgnore]
        //public virtual ICollection<Transaction> TransactionsSubCat { get; set; }

    } // CategoryMetadata

} // namespace
