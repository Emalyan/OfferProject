using System;

namespace OfferProject.Data.Data
{
    public class UpdateOfOffer
    {
        public long Id { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public long OfferId { get; set; }        
        public long Updateby { get; set; }
    }
}
