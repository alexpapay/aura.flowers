using System.ComponentModel.DataAnnotations;

namespace aura.flowers.Utils
{
    public enum ProductTypes
    {
        /// <summary>
        /// None - 0.
        /// </summary>
        [Display(Name = "none")]
        None = 0,

        /// <summary>
        /// Rent decor collection - 1
        /// </summary>
        [Display(Name = "Decor collection fro rent")]
        RentDecorCollection = 1,

        /// <summary>
        /// Interior decor - 2.
        /// </summary>
        [Display(Name = "Interior decor")]
        InteriorDecor = 2,

        /// <summary>
        /// Personal decor - 3
        /// </summary>
        [Display(Name = "Decore created for you")]
        PersonalDecor = 3,

        /// <summary>
        /// Wings - 4.
        /// </summary>
        [Display(Name = "Wings")]
        Wings = 4,

        /// <summary>
        /// Lamps - 5.
        /// </summary>
        [Display(Name = "Interior lamps")]
        Lamps = 5,

        /// <summary>
        /// Material - 6.
        /// </summary>
        [Display(Name = "Material")]
        Material = 6
    }
}
