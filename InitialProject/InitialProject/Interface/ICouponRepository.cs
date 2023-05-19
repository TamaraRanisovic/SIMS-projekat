using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface ICouponRepository
    {
        public void Delete(Coupon coupon);
        public List<Coupon> GetAll();
        public Coupon GetById(int id);
        public void UseCoupon(int couponId);
        public void RemoveExpiredCoupons();

    }
}
