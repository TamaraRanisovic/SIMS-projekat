using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface ITouristRepository
    {
        public Tourist GetById(int id);

        public List<Tourist> GetTourists(int tourId);

        public List<Coupon> GetTouristCoupons(int touristId);

        public List<Coupon> GetUsableTouristCoupons(int touristId);

        public void AddCoupon(int touristId, Coupon coupon);

    }
}
