using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    namespace Entities
    {
        public class PriceOffer
        {
            public int PriceOfferId { get; set; }
            [Column(TypeName = "decimal(8, 2)")]
            public decimal NewPrice { get; set; }
            public string PromtionalText { get; set; }

            public int BookId { get; set; }
            public Book Book { get; set; }
        }
    }
}
